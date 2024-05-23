using MediatR;
using Shoppy.Application.Features.Orders.Requests.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.Application.Features.Orders.Handlers.Query;

public class GetUserOrderHandler : IRequestHandler<GetUserOrderQuery, PagingResult<OrderQueryDto>>
{
    private readonly IOrderService _orderService;


    public GetUserOrderHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<PagingResult<OrderQueryDto>> Handle(GetUserOrderQuery request,
        CancellationToken cancellationToken)
    {
        if (!request.Page.HasValue || !request.Size.HasValue || request.Page.Value <= 0 || request.Size.Value <= 0)
        {
            request.Page = 1;
            request.Size = 10;
        }

        var result =
            await _orderService.FilterUserOrderAsync(request.Page.Value, request.Size.Value, cancellationToken);

        return result;
    }
}