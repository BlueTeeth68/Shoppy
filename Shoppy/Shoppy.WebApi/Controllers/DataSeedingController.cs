using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.DataSeeding.Requests.Command;
using Shoppy.Domain.Constants;

namespace Shoppy.WebAPI.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class DataSeedingController : ControllerBase
{
    private readonly IMediator _mediator;

    public DataSeedingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("users")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<IActionResult> SeedUserAsync([FromQuery] int size)
    {
        await _mediator.Send(new SeedUserCommand() { Size = size });
        return Ok();
    }

    [HttpPost("products")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<IActionResult> SeedProductAsync([FromQuery] SeedProductCommand request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}