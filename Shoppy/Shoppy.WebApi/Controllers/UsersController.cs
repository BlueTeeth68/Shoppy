using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Domain.Constants;

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
    public async Task<IActionResult> FilterUsersAsync([FromQuery] FilterUserQuery request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}