using MediatR;
using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Categories.Handlers.Command;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProductCategoryRepository.GetUpdateByIdAsync(request.Id, cancellationToken);
        if (entity is null)
            throw new NotFoundException("Category not found");

        CategoryMapper.UpdateCategoryCommandToEntity(request, ref entity);
        entity.UpdatedDateTime = DateTime.UtcNow;
        await _unitOfWork.ProductCategoryRepository.UpdateAsync(entity, cancellationToken);

        await _unitOfWork.SaveChangeAsync();
    }
}