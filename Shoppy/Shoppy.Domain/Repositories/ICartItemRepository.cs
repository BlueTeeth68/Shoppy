using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface ICartItemRepository: IBaseRepository<CartItem, Guid>
{
    Task<int> RemoveAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default);
}