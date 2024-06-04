using Refit;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Rating;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.WebMVC.Services.Interfaces.Refit;

public interface IOrdersClient
{
    [Get("/orders")]
    Task<BaseResult<object>?> CreateOrderAsync();

    [Get("/orders/account")]
    Task<BaseResult<PagingResult<OrderQueryDto>>?> FilterUserOrderAsync(int? page, int? size);

    [Get("/orders/{id}")]
    Task<BaseResult<OrderDto>?> GetOrderByIdAsync(Guid id);

    [Post("/orders/{id}/rating")]
    Task<BaseResult<object>?> AddReviewAsync(Guid id, [Body] AddRatingDto dto);
}