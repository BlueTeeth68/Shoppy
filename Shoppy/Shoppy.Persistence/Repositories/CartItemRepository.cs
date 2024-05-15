using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class CartItemRepository: BaseRepository<CartItem, Guid>, ICartItemRepository
{
    public CartItemRepository(AppDbContext dbContext, ILogger<CartItem> logger) : base(dbContext, logger)
    {
    }
}