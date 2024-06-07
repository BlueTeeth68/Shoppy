using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities.Base;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Persistence.Repositories.Base;

public class BaseRepository<T, TKey> : IBaseRepository<T, TKey>
    where T : BaseEntity<TKey>, IAggregateRoot
{
    protected readonly AppDbContext DbContext;

    protected ILogger<T> Logger;

    protected DbSet<T> DbSet => DbContext.Set<T>();

    public BaseRepository(AppDbContext dbContext, ILogger<T> logger)
    {
        DbContext = dbContext;
        Logger = logger;
    }

    public void SetRowVersion(T entity, byte[] version)
    {
        DbContext.Entry(entity).OriginalValues[nameof(entity.RowVersion)] = version;
    }

    public bool IsDbUpdateConcurrencyException(Exception ex)
    {
        return ex is DbUpdateConcurrencyException;
    }

    public IQueryable<T> GetQueryableSet()
    {
        return DbSet;
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default, bool disableTracking = false)
    {
        var query = DbSet;
        if (disableTracking)
            DbSet.AsNoTracking();
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken,
        bool disableTracking = false)
    {
        return await DbSet.FindAsync(id, cancellationToken);
    }

    public Task ToPaginationAsync(ref IQueryable<T> query, int page, int size)
    {
        query = query.Skip((page - 1) * size).Take(size);
        return Task.CompletedTask;
    }

    public async Task AddOrUpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id != null && entity.Id.Equals(default(TKey)))
        {
            await AddAsync(entity, cancellationToken);
        }
        else
        {
            await UpdateAsync(entity, cancellationToken);
        }
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedDateTime = DateTime.UtcNow;
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedDateTime = DateTime.UtcNow;
        DbSet.Update(entity);
        await Task.CompletedTask;
    }

    public Task UpdateRangeAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        DbSet.UpdateRange(entities);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task BulkInsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await DbContext.BulkInsertAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkUpdateAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        await DbContext.BulkUpdateAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkDeleteAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        await DbContext.BulkDeleteAsync(entities, cancellationToken: cancellationToken);
    }
}