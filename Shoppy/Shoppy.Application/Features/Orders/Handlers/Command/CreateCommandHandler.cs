using MediatR;
using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Identity;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Orders.Handlers.Command;

public class CreateCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;

    public CreateCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (!_currentUser.IsAuthenticated)
            throw new ForbiddenException("User do not login");

        var entity = OrderMapper.CreateOrderToOrder(request);

        entity.UserId = _currentUser.UserId;

        entity.CreatedDateTime = DateTime.UtcNow;
        await _unitOfWork.OrderRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangeAsync();
        return entity.Id;
    }
}