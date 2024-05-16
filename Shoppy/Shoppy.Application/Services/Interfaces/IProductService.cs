using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Application.Services.Interfaces;

public interface IProductService
{
    Task<PagingResult<FilterProductResult>> FilterProductAsync(FilterProductQuery request);
}