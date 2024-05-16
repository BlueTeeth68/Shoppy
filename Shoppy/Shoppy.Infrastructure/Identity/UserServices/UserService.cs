using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Persistence.Identity;
using Shoppy.Persistence.Specifications;

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
        var query = _userManager.Users;

        var parameter = Expression.Parameter(typeof(AppUser));
        Expression filterExpression = Expression.Constant(true); // default is "where true"

        //set default page size
        if (!filter.Page.HasValue || !filter.Size.HasValue)
        {
            filter.Page = 1;
            filter.Size = 10;
        }

        try
        {
            if (filter.Gender.HasValue)
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Equal(Expression.Property(parameter, nameof(AppUser.Gender)),
                        Expression.Constant(filter.Gender, typeof(Gender?))));
            }

            if (filter.Status.HasValue)
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Equal(Expression.Property(parameter, nameof(AppUser.Status)),
                        Expression.Constant(filter.Status)));
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                filterExpression = Expression.AndAlso(filterExpression,
                    Expression.Call(
                        Expression.Property(parameter, nameof(AppUser.FullName)),
                        typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })
                        ?? throw new NotSupportedException(
                            $"{nameof(string.Contains)} method is deprecated or not supported."),
                        Expression.Constant(filter.Name)));
            }

            //Default sort by modified date desc
            Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = q =>
                q.OrderByDescending(u => u.CreatedDateTime);

            if (filter.SortName != null && filter.SortName.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(u => u.FullName);
            }
            else if (filter.SortName != null && filter.SortName.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(u => u.FullName);
            }
            else if (filter.SortCreatedDate != null && filter.SortCreatedDate.Trim().ToLower().Equals("asc"))
            {
                orderBy = q => q.OrderBy(u => u.CreatedDateTime);
            }
            else if (filter.SortCreatedDate != null && filter.SortCreatedDate.Trim().ToLower().Equals("desc"))
            {
                orderBy = q => q.OrderByDescending(u => u.CreatedDateTime);
            }

            var userSpecification = new UserSpecification(
                criteria: Expression.Lambda<Func<AppUser, bool>>(filterExpression, parameter),
                orderByExpression: orderBy)
            {
                DisableTracking = true
            };

            var queryable = SpecificationEvaluator.GetQuery<AppUser>(query, userSpecification);

            var totalRecord = await queryable.CountAsync();

            var result = await queryable
                .Skip((filter.Page.Value - 1) * filter.Size.Value)
                .Take(filter.Size.Value)
                .Select(u => new FilterUserResult()
                {
                    FullName = u.FullName,
                    Gender = u.Gender,
                    Status = u.Status,
                    CreatedDateTime = u.CreatedDateTime,
                    PictureUrl = u.PictureUrl
                }).ToListAsync();

            var totalPages = (int)Math.Ceiling((double)totalRecord / filter.Size.Value);
            return new PagingResult<FilterUserResult>()
            {
                TotalPages = totalPages,
                TotalRecords = totalRecord,
                Results = result
            };
        }
        catch (Exception e)
        {
            throw new Exception($"Error when execute {nameof(this.FilterUserAsync)} method");
        }
    }
}