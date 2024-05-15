using MediatR;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.Products.Handlers.Query;

public class GetByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDetailQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        //Need to check delete
        var entity = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, disableTracking: true,
            cancellationToken: cancellationToken);
        if (entity == null)
            throw new NotFoundException($"Product {request.Id} do not found");
        var result = ProductMapper.ProductToProductDetail(entity);
        return result;
    }
}