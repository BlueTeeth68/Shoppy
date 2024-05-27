using MediatR;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Products.Handlers.Command;

public class UpdateCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException("Product has been deleted.");

        // if (!string.IsNullOrEmpty(request.Sku))
        // {
        //     if (await _unitOfWork.ProductRepository.ExistByExpressionAsync(c => c.Sku == request.Sku,
        //             cancellationToken))
        //         throw new ConflictException("Product sku has been existed");
        // }

        if (request.CategoryId != null)
        {
            if (await _unitOfWork.ProductCategoryRepository.ExistByExpressionAsync(pc => pc.Id == request.CategoryId,
                    cancellationToken))
                throw new NotFoundException("Product category does not exist");
        }
        
        ProductMapper.UpdateProductToEntity(request, ref entity);
        await _unitOfWork.ProductRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangeAsync();
    }
}