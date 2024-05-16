using MediatR;
using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Orders.Handlers.Command;

public class CreateCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = OrderMapper.CreateOrderToOrder(request);
        entity.CreatedDateTime = DateTime.UtcNow;
        await _unitOfWork.OrderRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangeAsync();
        return entity.Id;
    }
}