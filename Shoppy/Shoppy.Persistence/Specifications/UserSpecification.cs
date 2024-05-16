using System.Linq.Expressions;
using Shoppy.Domain.Specifications;
using Shoppy.Persistence.Identity;

namespace Shoppy.Persistence.Specifications;

public class UserSpecification(
    Expression<Func<AppUser, bool>>? criteria,
    Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>>? orderByExpression)
    : SpecificationBase<AppUser>(criteria, orderByExpression);