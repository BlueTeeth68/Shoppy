using MediatR;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Application.Features.Users.Handlers.Query;

public class FilterUserQueryHandler : IRequestHandler<FilterUserQuery, PagingResult<FilterUserResult>>
{
    private readonly IUserService _userService;

    public FilterUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<PagingResult<FilterUserResult>> Handle(FilterUserQuery request,
        CancellationToken cancellationToken)
    {
        return await _userService.FilterUserAsync(request);
    }
}