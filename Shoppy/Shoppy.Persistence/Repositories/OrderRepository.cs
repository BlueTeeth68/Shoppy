using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order, Guid>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext, ILogger<Order> logger) : base(dbContext, logger)
    {
    }

    public new async Task AddAsync(Order entity, CancellationToken cancellationToken = default)
    {
        var productList = new List<Product>();
        foreach (var i in entity.Items)
        {
            var product = await DbContext.Products.Where(p => p.Id == i.ProductId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (product == null || product.Quantity < i.Quantity)
            {
                throw new BadRequestException($"Product {i.ProductId} is not available");
            }

            product.NumberOfSale += i.Quantity;
            product.Quantity -= i.Quantity;
            product.Status = product.Quantity switch
            {
                < 0 => throw new BadRequestException(
                    $"Order quantity exceed current product quantity of product {product.Id}"),
                <= 0 => ProductStatus.OutOfStock,
                _ => product.Status
            };

            productList.Add(product);
        }

        entity.CreatedDateTime = DateTime.UtcNow;
        await DbSet.AddAsync(entity, cancellationToken);
        DbContext.Products.UpdateRange(productList);
    }
}