using System.Linq.Expressions;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Specifications;

public abstract class SpecificationBase<TEntity> where TEntity : class
{
    protected SpecificationBase(
        Expression<Func<TEntity, bool>>? criteria,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderByExpression
    )
    {
        Criteria = criteria;
        OrderByExpression = orderByExpression;
    }

    public bool IsSplitQuery { get; set; }

    public bool DisableTracking { get; set; }

    public Expression<Func<TEntity, bool>>? Criteria { get; }

    public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderByExpression { get; set; }

    // public Expression<Func<TEntity, object>>? OrderByExpression { get; set; }
    //
    // public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; set; }
}