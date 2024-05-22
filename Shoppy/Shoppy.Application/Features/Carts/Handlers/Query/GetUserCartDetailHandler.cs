using MediatR;
using Shoppy.Application.Features.Carts.Request.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.Application.Features.Carts.Handlers.Query;

public class GetUserCartDetailHandler: IRequestHandler<GetUserCartDetailQuery, CartDto>
{
    private readonly IUserService _userService;

    public GetUserCartDetailHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CartDto> Handle(GetUserCartDetailQuery request, CancellationToken cancellationToken)
    {
        var result = await _userService.GetUserCartDetailAsync();
        return result;
    }
}