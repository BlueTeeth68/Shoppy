using MediatR;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Products.Handlers.Command;

public class DeleteCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            throw new BadRequestException($"Product {request.Id} does not exist");

        _unitOfWork.ProductRepository.Delete(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}