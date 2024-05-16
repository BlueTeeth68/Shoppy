using System.Linq.Expressions;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Specifications;

namespace Shoppy.Persistence.Specifications;

public class ProductSpecification(
    Expression<Func<Product, bool>>? criteria,
    Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderByExpression)
    : SpecificationBase<Product>(criteria, orderByExpression);