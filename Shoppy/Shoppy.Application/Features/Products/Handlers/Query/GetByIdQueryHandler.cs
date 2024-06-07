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

    public Task<ProductDetailQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        //Need to check delete

        var result = _unitOfWork.ProductRepository.GetQueryableSet()
            .Where(p => p.Id == request.Id)
            .Select(p => new ProductDetailQueryResult()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                AuthorName = p.AuthorName,
                Publisher = p.Publisher,
                NumberOfPage = p.NumberOfPage,
                DateOfPublication = p.DateOfPublication,
                Price = p.Price,
                Quantity = p.Quantity,
                Status = p.Status,
                AvgRate = p.AvgRate,
                NumberOfSale = p.NumberOfSale,
                ProductThumbUrl = p.ProductThumbUrl,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name
            })
            .FirstOrDefault();

        return Task.FromResult(result ?? throw new NotFoundException($"Product {request.Id} do not found"));
    }
}