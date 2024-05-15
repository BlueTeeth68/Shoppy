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
}