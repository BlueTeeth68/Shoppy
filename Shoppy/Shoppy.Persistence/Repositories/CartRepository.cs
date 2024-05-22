using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class CartRepository: BaseRepository<Cart, Guid>, ICartRepository
{
    public CartRepository(AppDbContext dbContext, ILogger<Cart> logger) : base(dbContext, logger)
    {
    }
}