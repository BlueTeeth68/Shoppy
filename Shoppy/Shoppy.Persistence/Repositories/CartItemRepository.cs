using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class CartItemRepository : BaseRepository<CartItem, Guid>, ICartItemRepository
{
    public CartItemRepository(AppDbContext dbContext, ILogger<CartItem> logger) : base(dbContext, logger)
    {
    }

    public async Task<int> RemoveAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default)
    {
       return await DbSet.Where(i => i.CartId == cartId && i.ProductId == productId).ExecuteDeleteAsync(cancellationToken);
    }
}