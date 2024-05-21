using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.SharedLibrary.Models.Base;

namespace Shoppy.WebAPI.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<BaseResult<LoginResponse>>> LoginAsync([FromBody] LoginCommand request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<LoginResponse>()
        {
            Result = data
        };
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<BaseResult<RegisterResponse>>> RegisterAsync([FromBody] RegisterCommand request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<RegisterResponse>()
        {
            Result = data
        };
        return Created(nameof(RegisterAsync), result);
    }
}