using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Application.Mappers;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Identity;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.Persistence.Identity;
using Shoppy.Persistence.Specifications;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<UserService> _logger;
    private readonly ICurrentUser _currentUser;
    private readonly IUnitOfWork _unitOfWork;
    private const string DefaultUserPassword = "User@123456";

    public UserService(UserManager<AppUser> userManager, ILogger<UserService> logger, ICurrentUser currentUser,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _logger = logger;
        _currentUser = currentUser;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagingResult<FilterUserResult>> FilterUserAsync(FilterUserQuery filter)
    {
        var query = _userManager.Users;

        var parameter = Expression.Parameter(typeof(AppUser));
        Expression filterExpression = Expression.Constant(true); // default is "where true"

        //set default page size
        if (!filter.Page.HasValue || !filter.Size.HasValue || filter.Page.Value <= 0 || filter.Size.Value <= 0)
        {
            filter.Page = 1;
            filter.Size = 10;
        }

        try
        {
            if (filter.Gender.HasValue)
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Equal(Expression.Property(parameter, nameof(AppUser.Gender)),
                        Expression.Constant(filter.Gender, typeof(Gender?))));
            }

            if (filter.Status.HasValue)
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Equal(Expression.Property(parameter, nameof(AppUser.Status)),
                        Expression.Constant(filter.Status)));
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Call(
                        Expression.Property(parameter, nameof(AppUser.FullName)),
                        typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })
                        ?? throw new NotSupportedException(
                            $"{nameof(string.Contains)} method is deprecated or not supported."),
                        Expression.Constant(filter.Name)));
            }

            //Default sort by modified date desc
            Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = q =>
                q.OrderByDescending(u => u.CreatedDateTime);

            if (filter.SortName != null && filter.SortName.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(u => u.FullName);
            }
            else if (filter.SortName != null && filter.SortName.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(u => u.FullName);
            }
            else if (filter.SortCreatedDate != null && filter.SortCreatedDate.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(u => u.CreatedDateTime);
            }
            else if (filter.SortCreatedDate != null && filter.SortCreatedDate.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(u => u.CreatedDateTime);
            }

            var userSpecification = new UserSpecification(
                criteria: Expression.Lambda<Func<AppUser, bool>>(filterExpression, parameter),
                orderByExpression: orderBy)
            {
                DisableTracking = true
            };

            var queryable = SpecificationEvaluator.GetQuery(query, userSpecification);

            var totalRecord = await queryable.CountAsync();

            var result = await queryable
                .Skip((filter.Page.Value - 1) * filter.Size.Value)
                .Take(filter.Size.Value)
                .Select(u => new FilterUserResult()
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Gender = u.Gender,
                    Status = u.Status,
                    CreatedDateTime = u.CreatedDateTime,
                    PictureUrl = u.PictureUrl
                }).ToListAsync();

            var totalPages = (int)Math.Ceiling((double)totalRecord / filter.Size.Value);
            return new PagingResult<FilterUserResult>()
            {
                TotalPages = totalPages,
                TotalRecords = totalRecord,
                Results = result
            };
        }
        catch (Exception e)
        {
            _logger.LogError("Error when execute {} method.\nDate: {}.\nDetail: {}", nameof(this.FilterUserAsync),
                DateTime.UtcNow, e.Message);
            throw new Exception($"Error when execute {nameof(this.FilterUserAsync)} method");
        }
    }

    public async Task CreateUserDataAsync(int size)
    {
        var baseName = Guid.NewGuid().ToString();

        for (var i = 0; i < size; i++)
        {
            var user = new AppUser()
            {
                Email = $"{baseName}_{i}@gmail.com",
                FullName = $"{baseName}_{i}",
                UserName = $"{baseName}_{i}@gmail.com",
                Status = UserStatus.Active,
                Gender = Gender.Male
            };

            var cart = new Cart()
            {
                TotalItem = 0
            };

            user.Cart = cart;

            try
            {
                var result = await _userManager.CreateAsync(user, DefaultUserPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, RoleConstant.UserRole);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error when creating user {}th.\nDate{}\nDetail {}", i, DateTime.UtcNow, e.Message);
                throw new Exception($"Error when creating user {i}th");
            }
        }
    }

    public async Task<CartDto> GetUserCartDetailAsync()
    {
        var userQuery = _userManager.Users;

        var user = await userQuery.Where(u => u.Id == _currentUser.UserId)
            .Include(u => u.Cart)
            .ThenInclude(c => c.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync();

        if (user == null)
            throw new NotFoundException("User do not login");

        if (user.Cart == null)
        {
            user.Cart = new Cart();
            await _userManager.UpdateAsync(user);
        }

        var cart = CartMapper.CartToCartDto(user.Cart);
        return cart;
    }

    public async Task<int> GetCartTotalItemAsync()
    {
        var userQuery = _userManager.Users;
        var user = await userQuery.AsNoTracking().Where(u => u.Id == _currentUser.UserId)
            .Select(u => new AppUser
            {
                Cart = new Cart()
                {
                    TotalItem = u.Cart.TotalItem
                }
            })
            .FirstOrDefaultAsync()
            .ContinueWith(t => t.Result ?? throw new NotFoundException("User not found"));
        return user.Cart?.TotalItem ?? 0;
    }

    public async Task AddToCartAsync(AddCartItemCommand item, CancellationToken cancellationToken = default)
    {
        //check product
        var product = await _unitOfWork.ProductRepository
            .GetQueryableSet().AsNoTracking().Where(p => p.Id == item.ProductId && p.Status == ProductStatus.Active)
            .Select(p => new Product()
            {
                Price = p.Price,
                Quantity = p.Quantity,
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken)
            .ContinueWith(t => t.Result ?? throw new NotFoundException($"Product {item.ProductId} not found"),
                cancellationToken);

        //get cart 
        var user = await _userManager.Users.Where(u => u.Id == _currentUser.UserId)
            .Include(u => u.Cart)
            .ThenInclude(c => c.Items)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken)
            .ContinueWith(t => t.Result ?? throw new NotFoundException("User not found"), cancellationToken);

        //check cartItem exist
        user.Cart ??= new Cart();

        //Update/add new cart item
        var existedItem = user.Cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
        if (existedItem != null)
        {
            existedItem.Quantity += item.Quantity;
            if (existedItem.Quantity > product.Quantity)
            {
                throw new BadRequestException("Cart item quantity exceed product quantity");
            }
        }
        else
        {
            var cartItemEntity = new CartItem()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                CreatedDateTime = DateTime.UtcNow
            };

            user.Cart.Items.Add(cartItemEntity);
            user.Cart.TotalItem++;
        }

        await _userManager.UpdateAsync(user);
    }

    public async Task RemoveCartItemAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.Users.AsNoTracking().Where(u => u.Id == _currentUser.UserId)
            .Select(u => new AppUser()
            {
                CartId = u.CartId
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (user == null)
            throw new NotFoundException("User not found");

        if (user.CartId.HasValue)
        {
            var result =
                await _unitOfWork.CartItemRepository.RemoveAsync(user.CartId.Value, productId, cancellationToken);
            if (result > 0)
            {
                await _unitOfWork.CartRepository.GetQueryableSet()
                    .Where(c => c.Id == user.CartId.Value)
                    .ExecuteUpdateAsync(c => c.SetProperty(cart => cart.TotalItem, cart => cart.TotalItem - result),
                        cancellationToken: cancellationToken);
            }
        }
    }

    public async Task UpdateCartItemAsync(Guid productId, int quantity, CancellationToken cancellationToken = default)
    {
        //check product
        var product = await _unitOfWork.ProductRepository
            .GetQueryableSet().AsNoTracking().Where(p => p.Id == productId && p.Status == ProductStatus.Active)
            .Select(p => new Product()
            {
                Price = p.Price,
                Quantity = p.Quantity,
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken)
            .ContinueWith(t => t.Result ?? throw new NotFoundException($"Product {productId} not found"),
                cancellationToken);

        //get cart 
        var user = await _userManager.Users.Where(u => u.Id == _currentUser.UserId)
            .Include(u => u.Cart)
            .ThenInclude(c => c.Items)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken)
            .ContinueWith(t => t.Result ?? throw new NotFoundException("User not found"), cancellationToken);

        //check cartItem exist
        user.Cart ??= new Cart();

        //Update/add new cart item
        var existedItem = user.Cart.Items.FirstOrDefault(i => i.ProductId == productId);
        if (existedItem != null)
        {
            existedItem.Quantity = quantity;
            if (existedItem.Quantity > product.Quantity)
            {
                throw new BadRequestException("Cart item quantity exceed product quantity");
            }
        }
        else
        {
            var cartItemEntity = new CartItem()
            {
                ProductId = productId,
                Quantity = quantity,
                CreatedDateTime = DateTime.UtcNow
            };

            user.Cart.Items.Add(cartItemEntity);
            user.Cart.TotalItem++;
        }

        await _userManager.UpdateAsync(user);
    }

    public async Task RemoveCartAsync(CancellationToken cancellationToken = default)
    {
        var user = await _userManager.Users.Where(u => u.Id == _currentUser.UserId)
            .Select(u => new AppUser()
            {
                CartId = u.CartId
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (user == null)
            throw new NotFoundException("User not found");

        if (user.CartId.HasValue)
        {
            await _unitOfWork.CartItemRepository.GetQueryableSet()
                .Where(i => i.CartId == user.CartId.Value)
                .ExecuteDeleteAsync(cancellationToken);

            await _unitOfWork.CartRepository.GetQueryableSet()
                .Where(c => c.Id == user.CartId.Value)
                .ExecuteUpdateAsync(c => c.SetProperty(cart => cart.TotalItem, 0),
                    cancellationToken: cancellationToken);
        }
    }
}