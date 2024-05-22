using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.Persistence.Specifications;

namespace Shoppy.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<PagingResult<FilterProductResult>> FilterProductAsync(FilterProductQuery filter)
    {
        var query = _unitOfWork.ProductRepository.GetQueryableSet();

        var parameter = Expression.Parameter(typeof(Product));
        Expression filterExpression = Expression.Constant(true); // default is "where true"

        //set default page size
        if (!filter.Page.HasValue || !filter.Size.HasValue)
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
                q.OrderByDescending(u => u.UpdatedDateTime);

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
}