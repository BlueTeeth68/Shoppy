using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem, Guid>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext dbContext, ILogger<OrderItem> logger) : base(dbContext, logger)
    {
    }

    public new async Task<OrderItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default,
        bool disableTracking = false)
    {
        var query = DbSet;
        if (disableTracking)
        {
            query.AsNoTracking();
        }

        return await query.Where(i => i.Id == id)
            .Include(i => i.ProductRating)
            .Include(i => i.Order)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<OrderItem>> GetProductOrderDetailAsync(Guid productId)
    {
        return await DbSet.Where(i => i.ProductId == productId && i.IsReviewed && i.ProductRating != null)
            .Select(i => new OrderItem()
            {
                Id = i.Id,
                ProductRating = new ProductRating()
                {
                    RateValue = i.ProductRating.RateValue
                }
            })
            .ToListAsync();
    }
}