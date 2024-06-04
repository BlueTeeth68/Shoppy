using Microsoft.AspNetCore.Mvc;
using Refit;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.SharedLibrary.Models.Responses.Products;

namespace Shoppy.WebMVC.Services.Interfaces.Refit;

public interface IProductsClient
{
    [Get("/products")]
    Task<BaseResult<PagingResult<FilterProductResultDto>>?> FilterProductAsync([FromQuery] FilterProductDto? filter);

    [Get("/products/{id}/rating")]
    Task<BaseResult<PagingResult<ProductRatingDto>>?> FilterProductRatingAsync(
        [FromQuery] int? page,
        [FromQuery] int? size,
        [FromRoute] Guid id);

    [Get("/products/{id}")]
    Task<BaseResult<ProductDto>?> GetByIdAsync([FromRoute] Guid id);
}