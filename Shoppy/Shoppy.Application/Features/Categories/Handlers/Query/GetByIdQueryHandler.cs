using MediatR;
using Shoppy.Application.Features.Categories.Requests.Query;
using Shoppy.Application.Features.Categories.Results.Query;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Categories.Handlers.Query;

public class GetByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<CategoryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException($"Category {request.Id} does not exist");
        }

        return CategoryMapper.CategoryToCategoryResult(entity);
    }
}