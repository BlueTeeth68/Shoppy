using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Application.Features.Categories.Requests.Query;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Exceptions;

namespace Shoppy.WebAPI.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoriesController : ControllerBase
{
    private IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlLAsync()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand request)
    {
        var result = await _mediator.Send(request);
        return Created(nameof(CreateAsync), result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryCommand request)
    {
        if (id != request.Id)
            throw new BadRequestException("Id does not match");

        await _mediator.Send(request);
        return Ok();
    }
}