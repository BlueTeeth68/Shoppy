using MediatR;
using Shoppy.Application.Features.Categories.Requests.Query;
using Shoppy.Application.Features.Categories.Results.Query;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Categories.Handlers.Query;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoriesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CategoryResult>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.ProductCategoryRepository.GetAllAsync(cancellationToken);
        return CategoryMapper.CategoryToCategoryResult(entities);
    }
}