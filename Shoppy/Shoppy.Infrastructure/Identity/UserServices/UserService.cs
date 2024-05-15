using Microsoft.AspNetCore.Identity;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Persistence.Identity;

namespace Shoppy.Infrastructure.Identity.UserServices;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<PagingResult<FilterUserResult>> FilterUserAsync(FilterUserQuery filter)
    {
        // var query = _userManager.Users;
        //
        // var parameter = Expression.Parameter(typeof(AppUser));
        // Expression filterExpression = Expression.Constant(true); // default is "where true"
        //
        // //set default page size
        // if (!filter.Page.HasValue || !filter.Size.HasValue)
        // {
        //     filter.Page = 1;
        //     filter.Size = 10;
        // }
        //
        // try
        // {
        //     if (filter.Gender.HasValue)
        //     {
        //         filterExpression = Expression.AndAlso(filterExpression,
        //             Expression.Equal(Expression.Property(parameter, nameof(AppUser.Gender)),
        //                 Expression.Constant(filter.Gender, typeof(Gender?))));
        //     }
        //
        //     if (filter.Status.HasValue)
        //     {
        //         filterExpression = Expression.AndAlso(filterExpression,
        //             Expression.Equal(Expression.Property(parameter, nameof(AppUser.Status)),
        //                 Expression.Constant(filter.Status)));
        //     }
        //
        //     if (!string.IsNullOrEmpty(filter.Name))
        //     {
        //         filterExpression = Expression.AndAlso(filterExpression,
        //             Expression.Call(
        //                 Expression.Property(parameter, nameof(AppUser.FullName)),
        //                 typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })
        //                 ?? throw new NotImplementedException(
        //                     $"{nameof(string.Contains)} method is deprecated or not supported."),
        //                 Expression.Constant(filter.Name)));
        //     }
        //
        //     //Default sort by modified date desc
        //     Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = q =>
        //         q.OrderByDescending(u => u.CreatedDateTime);
        //
        //     var entities = await _unitOfWork.CourseRepository.GetPaginateAsync(
        //         filter: Expression.Lambda<Func<Course, bool>>(filterExpression, parameter),
        //         orderBy: orderBy,
        //         page: page,
        //         size: size
        //     );
        //     var result = CourseMapper.CourseToManageFilterCourseDto(entities);
        //     return result;
        // }
        // catch (Exception e)
        // {
        //     throw new Exception($"Error when execute {nameof(this.FilterUserAsync)} method");
        // }

        throw new NotImplementedException();
    }
}