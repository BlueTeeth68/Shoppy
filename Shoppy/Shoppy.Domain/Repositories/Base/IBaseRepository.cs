using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Repositories.Base;

public interface IBaseRepository<TEntity, in TKey> : IConcurrencyHandler<TEntity>
    where TEntity : BaseEntity<TKey>, IAggregateRoot
{
    IQueryable<TEntity> GetQueryableSet();

    Task<TEntity?> GetByIdAsync(TKey id, bool disableTracking = false);

    Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    void UpdateRange(List<TEntity> entities, CancellationToken cancellationToken = default);

    void Delete(TEntity entity);

    Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query);

    Task<T?> SingleOrDefaultAsync<T>(IQueryable<T> query);

    Task<List<T>> ToListAsync<T>(IQueryable<T> query);

    Task BulkInsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task BulkUpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task BulkDeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
}