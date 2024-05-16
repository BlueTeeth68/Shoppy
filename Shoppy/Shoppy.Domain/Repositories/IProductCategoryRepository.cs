using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IProductCategoryRepository : IBaseRepository<ProductCategory, Guid>
{
    Task<bool> ExistById(Guid id);
    Task<bool> ExistByName(string name);

    Task<ProductCategory?> GetUpdateByIdAsync(Guid id, CancellationToken cancellationToken);
}