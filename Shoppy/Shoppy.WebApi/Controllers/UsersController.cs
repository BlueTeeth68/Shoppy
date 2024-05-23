using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Features.Carts.Request.Query;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.WebAPI.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<ActionResult<BaseResult<PagingResult<FilterUserResult>>>> FilterUsersAsync(
        [FromQuery] FilterUserQuery request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<PagingResult<FilterUserResult>>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }

    [HttpGet("cart")]
    [Authorize]
    public async Task<ActionResult<BaseResult<CartDto>>> GetUserCartAsync()
    {
        var data = await _mediator.Send(new GetUserCartDetailQuery());
        var result = new BaseResult<CartDto>()
        {
            IsSuccess = true,
            Result = data
        };

        return Ok(result);
    }

    [HttpGet("cart/totalItem")]
    [Authorize]
    public async Task<ActionResult<BaseResult<int>>> GetCartTotalItemAsync()
    {
        var data = await _mediator.Send(new GetCartTotalItemQuery());
        var result = new BaseResult<int>()
        {
            IsSuccess = true,
            Result = data
        };

        return Ok(result);
    }

    [HttpPost("cart")]
    [Authorize]
    public async Task<IActionResult> AddToCartAsync([FromBody] AddCartItemCommand request)
    {
        await _mediator.Send(request);
        return Ok();
    }

    [HttpPatch("cart/item")]
    [Authorize]
    public async Task<IActionResult> UpdateCartQuantity([FromBody] UpdateCartItemCommand request)
    {
        await _mediator.Send(request);
        return Ok();
    }

    [HttpDelete("cart/{productId:guid}")]
    [Authorize]
    public async Task<IActionResult> RemoveFromCartAsync([FromRoute] Guid productId)
    {
        await _mediator.Send(new RemoveCartItemCommand() { ProductId = productId });
        return Ok();
    }
}