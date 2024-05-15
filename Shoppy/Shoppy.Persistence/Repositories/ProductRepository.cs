using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class ProductRepository: BaseRepository<Product, Guid>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext, ILogger<Product> logger) : base(dbContext, logger)
    {
    }
}