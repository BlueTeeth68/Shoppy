using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class ProductRatingRepository: BaseRepository<ProductRating, Guid>, IProductRatingRepository
{
    public ProductRatingRepository(AppDbContext dbContext, ILogger<ProductRating> logger) : base(dbContext, logger)
    {
    }
}