﻿using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Repositories.Base;

public interface IBaseRepository<TEntity, in TKey> : IConcurrencyHandler<TEntity>
    where TEntity : BaseEntity<TKey>, IAggregateRoot
{
    IQueryable<TEntity> GetQueryableSet();

    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default, bool disableTracking = false);

    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default, bool disableTracking = false);

    Task ToPaginationAsync(ref IQueryable<TEntity> query, int page, int size);

    Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity);

    Task BulkInsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    Task BulkUpdateAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    
    Task BulkDeleteAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
}