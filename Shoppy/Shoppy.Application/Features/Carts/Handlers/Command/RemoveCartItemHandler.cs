using MediatR;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Carts.Handlers.Command;

public class RemoveCartItemHandler: IRequestHandler<RemoveCartItemCommand>
{
    private readonly IUserService _userService;

    public RemoveCartItemHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        await _userService.RemoveCartItemAsync(productId: request.ProductId, cancellationToken: cancellationToken);
    }
}