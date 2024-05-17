using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Categories.Requests.Query;
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOrderCommand request)
    {
        var result = await _mediator.Send(request);
        return Created(nameof(CreateAsync), result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        return Ok(result);
    }
}