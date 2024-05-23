using MediatR;
using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Application.Mappers;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Identity;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Orders.Handlers.Command;

public class CreateCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;
    private readonly IUserService _userService;

    public CreateCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
        _userService = userService;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (!_currentUser.IsAuthenticated)
            throw new ForbiddenException("User do not login");
        var cart = await _userService.GetUserCartDetailAsync();
        var order = OrderMapper.CartDtoToOrder(cart);
        order.UserId = _currentUser.UserId;
        await _unitOfWork.OrderRepository.AddAsync(order, cancellationToken);
        await _unitOfWork.SaveChangeAsync();
        await _userService.RemoveCartAsync(cancellationToken);
    }
}