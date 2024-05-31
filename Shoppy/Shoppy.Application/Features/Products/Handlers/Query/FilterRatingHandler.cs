using MediatR;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Responses.Products;

namespace Shoppy.Application.Features.Products.Handlers.Query;

public class FilterRatingHandler : IRequestHandler<FilterProductRatingQuery, PagingResult<ProductRatingDto>>
{
    private readonly IProductService _productService;

    public FilterRatingHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<PagingResult<ProductRatingDto>> Handle(FilterProductRatingQuery request,
        CancellationToken cancellationToken)
    {
        return await _productService.FilterProductRatingAsync(request);
    }
}