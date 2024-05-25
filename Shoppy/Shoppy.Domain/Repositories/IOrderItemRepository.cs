using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IOrderItemRepository: IBaseRepository<OrderItem, Guid>
{
    Task<List<OrderItem>> GetProductOrderDetailAsync(Guid productId);
    
}