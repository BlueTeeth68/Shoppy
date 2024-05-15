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

    public async Task<T?> GetByIdAsync(TKey id, bool disableTracking = false)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<PagingResult<T>> GetPaginateAsync(Expression<Func<T, bool>>? filter,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, int page, int size, string? includeProperties = null,
        bool disableTracking = false)
    {
        IQueryable<T> query = DbSet;
        var result = new PagingResult<T>();

        try
        {
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            result.TotalRecords = await query.CountAsync();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (page <= 0)
            {
                throw new BadRequestException("Page must be greater than 0.");
            }

            if (size <= 0)
            {
                throw new BadRequestException("Size must be greater than 0.");
            }

            await ToPaginationAsync(ref query, page, size);
            result.Results = await query.ToListAsync();
            result.TotalPages = (int)Math.Ceiling((double)result.TotalRecords / size);

            return result;
        }
        catch (Exception e)
        {
            Logger.LogError("Error when filter data of {class name} entity.\nDetail: {error}", typeof(T), e.Message);
            throw new Exception(e.Message);
        }
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

    public async Task BulkInsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await _dbContext.BulkInsertAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await _dbContext.BulkUpdateAsync(entities, cancellationToken: cancellationToken);
    }

    public async Task BulkDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await _dbContext.BulkDeleteAsync(entities, cancellationToken: cancellationToken);
    }
}