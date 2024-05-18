using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Application.Services.Interfaces;

public interface IUserService
{
    Task<PagingResult<FilterUserResult>> FilterUserAsync(FilterUserQuery filter);

    Task CreateUserDataAsync(int size);
}