using MediatR;
using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Application.Utils;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Categories.Handlers.Command;

public class CreateCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.ProductCategoryRepository.ExistByExpressionAsync(pc => pc.Name == request.Name, cancellationToken))
            throw new BadRequestException("Name has been existed");

        var entity = new ProductCategory()
        {
            Name = StringUtils.FormatName(request.Name),
            Description = request.Description,
            CreatedDateTime = DateTime.UtcNow,
        };

        await _unitOfWork.ProductCategoryRepository.AddAsync(entity, cancellationToken);

        await _unitOfWork.SaveChangeAsync();
        return entity.Id;
    }
}