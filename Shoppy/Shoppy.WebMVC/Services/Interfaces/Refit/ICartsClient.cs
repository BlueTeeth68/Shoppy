using Refit;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Carts;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.WebMVC.Services.Interfaces.Refit;

public interface ICartsClient
{
    [Get("/users/cart")]
    Task<BaseResult<CartDto>?> GetCartAsync();

    [Get("/users/cart/totalItem")]
    Task<BaseResult<int>?> GetCartTotalItemAsync();

    [Post("/users/cart")]
    Task<BaseResult<object>?> AddToCartAsync([Body] AddCartItemDto data);

    [Delete("/users/cart/{id}")]
    Task<BaseResult<object>?> RemoveFromCartAsync(Guid id);

    [Patch("/users/cart/item")]
    Task<BaseResult<object>?> UpdateCartItemAsync([Body] UpdateCartItemDto data);
}