using System.Linq.Expressions;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Entities.Base;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Persistence.Repositories.Base;

public class BaseRepository<T, TKey> : IBaseRepository<T, TKey>
    where T : BaseEntity<TKey>, IAggregateRoot
{
    private AppDbContext _dbContext;

    protected ILogger<T> Logger;

    protected DbSet<T> DbSet => _dbContext.Set<T>();

    public BaseRepository(AppDbContext dbContext, ILogger<T> logger)
    {
        _dbContext = dbContext;
        Logger = logger;
    }

    public void SetRowVersion(T entity, byte[] version)
    {
        _dbContext.Entry(entity).OriginalValues[nameof(entity.RowVersion)] = version;
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
        if (entity.Id.Equals(default(TKey)))
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

    public void UpdateRange(List<T> entities, CancellationToken cancellationToken = default)
    {
        DbSet.UpdateRange(entities);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public async Task BulkInsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken=default)
    {
        await _dbContext.BulkInsertAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken= default)
    {
        await _dbContext.BulkUpdateAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _dbContext.BulkDeleteAsync(entities, cancellationToken: cancellationToken);
    }
}