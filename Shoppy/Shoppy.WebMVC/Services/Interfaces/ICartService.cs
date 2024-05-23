using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface ICartService
{
    Task<BaseResult<CartDto>?> GetCartAsync(string? accessToken);
}