using MediatR;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Products.Handlers.Command;

public class CreateCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.ProductRepository.ExistByExpressionAsync(p => p.Sku == request.Sku, cancellationToken))
        {
            throw new ConflictException("Product Sku has been existed");
        }

        var entity = ProductMapper.CreateProductCommandToProduct(request);

        var category =
            await _unitOfWork.ProductCategoryRepository.GetByIdAsync(entity.CategoryId, cancellationToken,
                disableTracking: true);
        if (category == null)
        {
            throw new BadRequestException($"Product category {category} does not exist.");
        }

        entity.Status = ProductStatus.Active;
        entity.CreatedDateTime = DateTime.UtcNow;

        await _unitOfWork.ProductRepository.AddAsync(entity, cancellationToken);

        await _unitOfWork.SaveChangeAsync();

        return entity.Id;
    }
}