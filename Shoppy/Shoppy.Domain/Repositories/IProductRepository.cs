using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product, Guid>
{
    
}