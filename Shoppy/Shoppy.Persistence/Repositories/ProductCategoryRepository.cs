using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class ProductCategoryRepository : BaseRepository<ProductCategory, Guid>, IProductCategoryRepository
{
    public ProductCategoryRepository(AppDbContext dbContext, ILogger<ProductCategory> logger) : base(dbContext, logger)
    {
    }

    public new async Task<ProductCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken,
        bool disableTracking = false)
    {
        var query = DbSet;
        if (disableTracking)
        {
            query.AsNoTracking();
        }

        return await query.Where(pc => pc.Id == id)
            .Select(pc => new ProductCategory()
            {
                Id = pc.Id,
                Name = pc.Name,
                Description = pc.Description
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }


    public new async Task<List<ProductCategory>> GetAllAsync(CancellationToken cancellationToken = default,
        bool disableTracking = false)
    {
        var query = DbSet;
        if (disableTracking)
            query.AsNoTracking();
        return await query.Select(pc => new ProductCategory()
        {
            Id = pc.Id,
            Name = pc.Name,
            Description = pc.Description
        }).ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistByExpressionAsync(Expression<Func<ProductCategory, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        var entityId = await DbSet.Where(expression)
            .Select(pc => pc.Id)
            .FirstOrDefaultAsync();

        return entityId != Guid.Empty;
    }

    public async Task<ProductCategory?> GetUpdateByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbSet.Where(pc => pc.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}