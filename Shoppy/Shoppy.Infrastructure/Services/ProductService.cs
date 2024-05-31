using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Application.Mappers;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.Persistence.Identity;
using Shoppy.Persistence.Specifications;
using Shoppy.SharedLibrary.Models.Responses.Products;

namespace Shoppy.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductService> _logger;
    private readonly IFileService _fileService;
    private readonly UserManager<AppUser> _userManager;
    private const string ImageFolder = "images/product/thumbImage";

    public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger, IFileService fileService,
        UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _fileService = fileService;
        _userManager = userManager;
    }

    public async Task<PagingResult<FilterProductResult>> FilterProductAsync(FilterProductQuery filter)
    {
        var query = _unitOfWork.ProductRepository.GetQueryableSet();

        var parameter = Expression.Parameter(typeof(Product));
        Expression filterExpression = Expression.Constant(true); // default is "where true"

        //set default page size
        if (!filter.Page.HasValue || !filter.Size.HasValue || filter.Page.Value <= 0 || filter.Size.Value <= 0)
        {
            filter.Page = 1;
            filter.Size = 10;
        }

        try
        {
            if (filter.Status.HasValue)
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Equal(Expression.Property(parameter, nameof(Product.Status)),
                        Expression.Constant(filter.Status)));
            }

            if (filter.CategoryId.HasValue)
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Equal(Expression.Property(parameter, nameof(Product.CategoryId)),
                        Expression.Constant(filter.CategoryId)));
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Call(
                        Expression.Property(parameter, nameof(Product.Name)),
                        typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })
                        ?? throw new NotSupportedException(
                            $"{nameof(string.Contains)} method is deprecated or not supported."),
                        Expression.Constant(filter.Name)));
            }

            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = q =>
                q.OrderByDescending(u => u.CreatedDateTime);

            if (filter.SortName != null && filter.SortName.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(p => p.Name);
            }
            else if (filter.SortName != null && filter.SortName.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(p => p.Name);
            }
            else if (filter.SortPrice != null && filter.SortPrice.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(p => p.Price);
            }
            else if (filter.SortPrice != null && filter.SortPrice.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(p => p.Price);
            }
            else if (filter.SortAvgRate != null && filter.SortAvgRate.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(p => p.AvgRate);
            }
            else if (filter.SortAvgRate != null && filter.SortAvgRate.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(p => p.AvgRate);
            }
            else if (filter.SortNumberOfSale != null && filter.SortNumberOfSale.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(p => p.NumberOfSale);
            }
            else if (filter.SortNumberOfSale != null && filter.SortNumberOfSale.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(p => p.NumberOfSale);
            }

            var userSpecification = new ProductSpecification(
                criteria: Expression.Lambda<Func<Product, bool>>(filterExpression, parameter),
                orderByExpression: orderBy)
            {
                DisableTracking = true
            };

            var queryable = SpecificationEvaluator.GetQuery(query, userSpecification);

            var totalRecord = await queryable.CountAsync();

            var result = await queryable
                .Skip((filter.Page.Value - 1) * filter.Size.Value)
                .Take(filter.Size.Value)
                .Select(p => new FilterProductResult()
                {
                    Id = p.Id,
                    Price = p.Price,
                    Status = p.Status,
                    AvgRate = p.AvgRate,
                    NumberOfSale = p.NumberOfSale,
                    Name = p.Name,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    ProductThumbUrl = p.ProductThumbUrl
                }).ToListAsync();

            var totalPages = (int)Math.Ceiling((double)totalRecord / filter.Size.Value);
            return new PagingResult<FilterProductResult>()
            {
                TotalPages = totalPages,
                TotalRecords = totalRecord,
                Results = result
            };
        }
        catch (Exception e)
        {
            _logger.LogError("Error when execute {} method at {}.\nDetail {}", nameof(this.FilterProductAsync),
                DateTime.UtcNow, e.Message);
            throw new Exception($"Error when execute {nameof(this.FilterProductAsync)} method");
        }
    }

    public async Task<PagingResult<ProductRatingDto>> FilterProductRatingAsync(FilterProductRatingQuery request)
    {
        var ratingQuery = _unitOfWork.ProductRatingRepository.GetQueryableSet();
        var userQuery = _userManager.Users;

        if (!request.Page.HasValue || !request.Size.HasValue || request.Page.Value <= 0 || request.Size.Value <= 0)
        {
            request.Page = 1;
            request.Size = 10;
        }

        var totalRecord = await ratingQuery.Where(r => r.OrderItem.ProductId == request.ProductId)
            .Select(r => r.Id)
            .Skip((request.Page.Value - 1) * request.Size.Value)
            .Take(request.Size.Value)
            .CountAsync();

        var data = ratingQuery.Where(r => r.OrderItem.ProductId == request.ProductId)
            .Join(userQuery,
                rating => rating.OrderItem.Order.UserId,
                user => user.Id,
                (rating, user) => new ProductRatingDto()
                {
                    Id = rating.Id,
                    Comment = rating.Comment,
                    Date = rating.CreatedDateTime,
                    RateValue = rating.RateValue,
                    UserName = user.FullName,
                    PictureUrl = user.PictureUrl
                })
            .Skip((request.Page.Value - 1) * request.Size.Value)
            .Take(request.Size.Value)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)totalRecord / request.Size.Value);

        var result = new PagingResult<ProductRatingDto>()
        {
            TotalPages = totalPages,
            TotalRecords = totalRecord,
            Results = data
        };
        return result;
    }

    public async Task SeedDataAsync(int size, Guid categoryId, CancellationToken cancellationToken = default)
    {
        if (!await _unitOfWork.ProductCategoryRepository.ExistByExpressionAsync(pc => pc.Id == categoryId,
                cancellationToken))
        {
            throw new BadRequestException("Category does not exist");
        }

        var baseName = Guid.NewGuid().ToString();

        var products = new List<Product>();

        for (var i = 0; i < size; i++)
        {
            products.Add(new Product()
            {
                Id = Guid.NewGuid(),
                Name = $"Product_{baseName}",
                Quantity = 1000,
                ProductThumbUrl = "https://m.media-amazon.com/images/I/81XWahQULEL._SY425_.jpg",
                CreatedDateTime = DateTime.UtcNow,
                Price = 15,
                NumberOfPage = 300,
                CategoryId = categoryId,
                Status = ProductStatus.Active
            });
        }

        try
        {
            await _unitOfWork.ProductRepository.BulkInsertAsync(products, cancellationToken: cancellationToken);
            await _unitOfWork.SaveChangeAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error seeding data: {}", e.Message);
            throw new Exception("Error when seed product data");
        }
    }

    public async Task<string> UpdateProductThumbAsync(UpdateProductImageCommand request,
        CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException($"Product {request.Id} not found");
        }

        var fileName = $"product_{product.Id}";

        var uploadedFile = await _fileService.UploadImageAsync(request.File, ImageFolder, fileName);

        product.ProductThumbUrl = uploadedFile;

        await _unitOfWork.ProductRepository.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangeAsync();

        return product.ProductThumbUrl;
    }

    public async Task<Guid> CreateAsync(CreateProductCommand request, CancellationToken cancellationToken = default)
    {
        var entity = ProductMapper.CreateProductCommandToProduct(request);

        var category =
            await _unitOfWork.ProductCategoryRepository.GetByIdAsync(entity.CategoryId, cancellationToken,
                disableTracking: true);
        if (category == null)
        {
            throw new BadRequestException($"Product category {category} does not exist.");
        }

        entity.Id = Guid.NewGuid();

        var fileName = $"product_{entity.Id}";

        var uploadedFile = await _fileService.UploadImageAsync(request.ProductThumb, ImageFolder, fileName);

        entity.ProductThumbUrl = uploadedFile;
        entity.Status = ProductStatus.Active;
        entity.CreatedDateTime = DateTime.UtcNow;

        await _unitOfWork.ProductRepository.AddAsync(entity, cancellationToken);

        await _unitOfWork.SaveChangeAsync();

        return entity.Id;
    }

    public async Task UpdateAsync(UpdateProductCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException("Product has been deleted.");
        if (request.CategoryId != null)
        {
            if (!await _unitOfWork.ProductCategoryRepository.ExistByExpressionAsync(pc => pc.Id == request.CategoryId,
                    cancellationToken))
                throw new NotFoundException("Product category does not exist");
        }

        ProductMapper.UpdateProductToEntity(request, ref entity);

        if (request.ProductThumb != null)
        {
            var fileName = $"product_{entity.Id}";

            var uploadedFile = await _fileService.UploadImageAsync(request.ProductThumb, ImageFolder, fileName);
            entity.ProductThumbUrl = uploadedFile;
        }

        await _unitOfWork.ProductRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangeAsync();
    }
}