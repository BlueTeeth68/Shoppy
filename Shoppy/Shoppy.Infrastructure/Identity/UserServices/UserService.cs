using System.Linq.Expressions;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Persistence.Identity;
using Shoppy.Persistence.Specifications;

namespace Shoppy.Infrastructure.Identity.UserServices;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly ILogger<UserService> _logger;
    private const string DefaultUserPassword = "User@123456";

    public UserService(UserManager<AppUser> userManager, ILogger<UserService> logger,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _logger = logger;
        _roleManager = roleManager;
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

    public async Task BulkCreateUserDataAsync(int size)
    {
        var userRole = await _roleManager.FindByNameAsync(RoleConstant.UserRole)
            .ContinueWith(t => t.Result ?? throw new NotFoundException($"Role {RoleConstant.UserRole} does not exist"));

        var passwordHasher = new PasswordHasher<AppUser>();

        var baseName = Guid.NewGuid().ToString();

        var user = new AppUser();
        var users = new List<AppUser>();
        Cart cart;

        for (var i = 0; i < size; i++)
        {
            var email = $"{baseName}_{i}@gmail.com";
            var emailNormalize = email.ToUpper();

            user.UserName = email;
            user.NormalizedUserName = emailNormalize;
            user.Email = email;
            user.NormalizedEmail = emailNormalize;
            user.LockoutEnabled = true;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.FullName = $"{baseName}_{i}";
            user.Gender = Gender.Female;
            user.Status = UserStatus.Active;
            user.CreatedDateTime = DateTime.UtcNow;
            user.UpdatedDateTime = DateTime.UtcNow;
            user.PasswordHash = passwordHasher.HashPassword(user, DefaultUserPassword);

            cart = new Cart();
            user.Cart = cart;

            users.Add(user);
        }
    }
}