using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.Application.Services.Interfaces;

public interface IUserService
{
    Task<PagingResult<FilterUserResult>> FilterUserAsync(FilterUserQuery filter);

    Task CreateUserDataAsync(int size);

    Task<CartDto> GetUserCartDetailAsync();
    Task<int> GetCartTotalItemAsync();

    Task AddToCartAsync(AddCartItemCommand item, CancellationToken cancellationToken = default);

    Task RemoveCartItemAsync(Guid productId, CancellationToken cancellationToken = default);
    Task UpdateCartItemAsync(Guid productId, int quantity, CancellationToken cancellationToken = default);
}