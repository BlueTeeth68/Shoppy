using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Application.Features.Orders.Requests.Query;
using Shoppy.Application.Features.ProductRatings.Request.Command;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Orders;

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
    [Authorize]
    public async Task<ActionResult<BaseResult<object>>> CreateAsync()
    {
        await _mediator.Send(new CreateOrderCommand());
        var result = new BaseResult<object>()
        {
            IsSuccess = true,
            Result = null
        };
        return Ok(result);
    }

    [HttpGet("account")]
    [Authorize]
    public async Task<ActionResult<BaseResult<PagingResult<OrderQueryDto>>>> GetUserOrderAsync(
        [FromQuery] GetUserOrderQuery request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<PagingResult<OrderQueryDto>>()
        {
            IsSuccess = true,
            Result = data
        };

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<BaseResult<OrderDto>>> GetByIdAsync([FromRoute] Guid id)
    {
        var data = await _mediator.Send(new GetOrderDetailQuery()
        {
            Id = id
        });

        var result = new BaseResult<OrderDto>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }

    [HttpPost("{id:guid}/rating")]
    [Authorize]
    public async Task<ActionResult<BaseResult<object>>> AddRatingAsync([FromBody] CreateRatingCommand request, Guid id)
    {
        if (id != request.OrderItemId)
            throw new BadRequestException("Id is not match");
        await _mediator.Send(request);
        var result = new BaseResult<object>()
        {
            IsSuccess = true,
            Result = null
        };
        return Ok(result);
    }
}