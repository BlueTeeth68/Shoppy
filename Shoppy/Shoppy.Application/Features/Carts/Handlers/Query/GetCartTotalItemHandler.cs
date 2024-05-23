using MediatR;
using Shoppy.Application.Features.Carts.Request.Query;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Carts.Handlers.Query;

public class GetCartTotalItemHandler: IRequestHandler<GetCartTotalItemQuery, int>
{
    private readonly IUserService _userService;

    public GetCartTotalItemHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<int> Handle(GetCartTotalItemQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetCartTotalItemAsync();
    }
}