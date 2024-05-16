using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext, ILogger<Product> logger) : base(dbContext, logger)
    {
    }

    public async Task<bool> ExistByExpressionAsync(Expression<Func<Product, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        var query = DbSet;
        var result = await DbSet.Where(expression)
            .Select(p => p.Id)
            .FirstOrDefaultAsync(cancellationToken);
        return result != Guid.Empty;
    }
}