using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IProductRatingRepository: IBaseRepository<ProductRating, Guid>
{
    
}