using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;

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
}