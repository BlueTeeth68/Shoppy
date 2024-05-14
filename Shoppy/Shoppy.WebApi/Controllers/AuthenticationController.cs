using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Authentication.Requests.Command;

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
    public async Task<IActionResult> LoginAsync([FromBody] LoginCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand request)
    {
        var result = await _mediator.Send(request);
        return Created(nameof(RegisterAsync), result);
    }
}