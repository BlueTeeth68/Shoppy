using MediatR;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Application.Features.Products.Handlers.Query;

public class FilterQueryHandler : IRequestHandler<FilterProductQuery, PagingResult<FilterProductResult>>
{
    private readonly IProductService _productService;

    public FilterQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<PagingResult<FilterProductResult>> Handle(FilterProductQuery filter,
        CancellationToken cancellationToken)
    {
        return await _productService.FilterProductAsync(filter);
    }
}