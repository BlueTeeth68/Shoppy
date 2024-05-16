using System.Linq.Expressions;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IProductCategoryRepository : IBaseRepository<ProductCategory, Guid>
{
    Task<bool> ExistByExpressionAsync(Expression<Func<ProductCategory, bool>> expression,
        CancellationToken cancellationToken = default);

    Task<ProductCategory?> GetUpdateByIdAsync(Guid id, CancellationToken cancellationToken);
}