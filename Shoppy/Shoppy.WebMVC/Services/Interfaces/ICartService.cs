using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface ICartService
{
    Task<BaseResult<CartDto>?> GetCartAsync(string? accessToken);

    Task<BaseResult<int>?> GetCartTotalItemAsync(string? accessToken);

    Task<BaseResult<object>?> AddToCartAsync(Guid productId, string? accessToken);

    Task<BaseResult<object>?> RemoveFromCartAsync(Guid productId, string? accessToken);
    
    Task<BaseResult<object>?> UpdateCartItemAsync(Guid productId, int quantity, string? accessToken);
}