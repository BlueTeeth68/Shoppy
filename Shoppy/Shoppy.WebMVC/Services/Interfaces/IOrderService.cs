using Shoppy.SharedLibrary.Models.Base;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface IOrderService
{
    Task<BaseResult<object>?> CreateOrderAsync(string? accessToken);
}