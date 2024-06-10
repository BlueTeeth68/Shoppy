using MediatR;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Carts.Handlers.Command;

public class AddCartItemHandler: IRequestHandler<AddCartItemCommand>
{
    private readonly IUserService _userService;

    public AddCartItemHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(AddCartItemCommand request, CancellationToken cancellationToken = default)
    {
        await _userService.AddToCartAsync(request, cancellationToken);
    }
    
}