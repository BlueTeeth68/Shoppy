using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.Application.Services.Interfaces;

public interface IOrderService
{
    Task<PagingResult<OrderQueryDto>> FilterUserOrderAsync(int page, int size,
        CancellationToken cancellationToken = default);
}