using Microsoft.EntityFrameworkCore;
using Shoppy.Domain.Entities.Base;
using Shoppy.Domain.Specifications;

namespace Shoppy.Persistence.Specifications;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> queryableInput,
        SpecificationBase<TEntity> specification) where TEntity : class
    {
        var queryable = queryableInput;

        if (specification.Criteria is not null)
        {
            queryable = queryableInput.Where(specification.Criteria);
        }

        if (specification.DisableTracking)
        {
            queryable.AsNoTracking();
        }

        if (specification.IsSplitQuery)
        {
            queryable.AsSplitQuery();
        }

        if (specification.OrderByExpression is not null)
        {
            queryable = specification.OrderByExpression(queryable);
        }

        return queryable;
    }
}