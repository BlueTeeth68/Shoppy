using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class OrderRepository: BaseRepository<Order, Guid>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext, ILogger<Order> logger) : base(dbContext, logger)
    {
    }
}