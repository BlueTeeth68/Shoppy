using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.DataSeeding.Requests.Command;
using Shoppy.Domain.Constants;
using Shoppy.SharedLibrary.Models.Base;

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
    public async Task<ActionResult<BaseResult<object>>> SeedUserAsync([FromQuery] int size)
    {
        await _mediator.Send(new SeedUserCommand() { Size = size });
        var result = new BaseResult<object>()
        {
            IsSuccess = true,
            Result = null,
            Error = null
        };
        return Ok(result);
    }

    [HttpPost("products")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<ActionResult<BaseResult<object>>> SeedProductAsync([FromQuery] SeedProductCommand request)
    {
        await _mediator.Send(request);
        var result = new BaseResult<object>()
        {
            IsSuccess = true,
            Result = null,
            Error = null
        };
        return Ok(result);
    }
}