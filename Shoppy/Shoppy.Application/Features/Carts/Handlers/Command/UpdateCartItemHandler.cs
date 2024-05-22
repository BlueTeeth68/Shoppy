using MediatR;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Carts.Handlers.Command;

public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemCommand>
{
    private readonly IUserService _userService;

    public UpdateCartItemHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateCartItemAsync(request.ProductId, request.Quantity, cancellationToken);
    }
}