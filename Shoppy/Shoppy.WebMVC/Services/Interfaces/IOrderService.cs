using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface IOrderService
{
    Task<BaseResult<object>?> CreateOrderAsync(string? accessToken);

    Task<BaseResult<PagingResult<OrderQueryDto>>?> FilterUserOrderAsync(int page, int size, string? accessToken);
}