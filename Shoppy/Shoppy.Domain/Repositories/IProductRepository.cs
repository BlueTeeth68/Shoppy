using System.Linq.Expressions;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product, Guid>
{
    Task<bool> ExistByExpressionAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default);
}