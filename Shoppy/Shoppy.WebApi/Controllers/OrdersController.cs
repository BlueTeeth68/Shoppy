using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Application.Features.Orders.Requests.Query;
using Shoppy.Application.Features.Orders.Results;
using Shoppy.SharedLibrary.Models.Base;

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
    public async Task<IActionResult> CreateAsync()
    {
        await _mediator.Send(new CreateOrderCommand());
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderDetailQuery>> GetByIdAsync([FromRoute] Guid id)
    {
        var data = await _mediator.Send(new GetOrderDetailQuery()
        {
            Id = id
        });

        var result = new BaseResult<OrderDetailQuery>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }
}