using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Orders.Requests.Command;

namespace Shoppy.WebAPI.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> CreateAsync([FromBody] CreateOrderCommand request)
    {
        var result = await _mediator.Send(request);
        return Created(nameof(CreateAsync), result);
    }
}