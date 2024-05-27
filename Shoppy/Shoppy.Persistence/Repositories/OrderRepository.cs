using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

    public async Task AddAsync(Order entity, CancellationToken cancellationToken = default)
    {
        var productList = new List<Product>();
        foreach (var i in entity.Items)
        {
            var product = await _dbContext.Products.Where(p => p.Id == i.ProductId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (product == null || product.Quantity < i.Quantity)
            {
                throw new BadRequestException($"Product {i.ProductId} is not available");
            }

            product.NumberOfSale = i.Quantity;
            product.Quantity = product.Quantity = i.Quantity;
            productList.Add(product);
        }

        entity.CreatedDateTime = DateTime.UtcNow;
        await DbSet.AddAsync(entity, cancellationToken);
        await _dbContext.Products.AddRangeAsync(productList, cancellationToken);
    }
}