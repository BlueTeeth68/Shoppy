using System.Linq.Expressions;
using MediatR;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Users.Handlers.Query;

public class FilterUserQueryHandler: IRequestHandler<FilterUserQuery, PagingResult<FilterUserResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;

    public FilterUserQueryHandler(IUnitOfWork unitOfWork, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
    }

    public async Task<PagingResult<FilterUserResult>> Handle(FilterUserQuery request, CancellationToken cancellationToken)
    {
        return await _userService.FilterUserAsync(request);
    }
}