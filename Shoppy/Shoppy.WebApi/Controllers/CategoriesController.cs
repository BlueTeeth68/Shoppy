using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Application.Features.Categories.Requests.Query;
using Shoppy.Application.Features.Categories.Results.Query;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Exceptions;
using Shoppy.SharedLibrary.Models.Base;

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
    public async Task<ActionResult<BaseResult<List<CategoryResult>>>> GetAlLAsync()
    {
        var data = await _mediator.Send(new GetAllCategoriesQuery());

        var result = new BaseResult<List<CategoryResult>>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseResult<CategoryResult>>> GetByIdAsync([FromRoute] Guid id)
    {
        var data = await _mediator.Send(new GetCategoryByIdQuery(id));

        var result = new BaseResult<CategoryResult>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateCategoryCommand request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<Guid>()
        {
            IsSuccess = true,
            Result = data
        };
        return Created(nameof(CreateAsync), result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<ActionResult<BaseResult<object>>> UpdateAsync([FromRoute] Guid id,
        [FromBody] UpdateCategoryCommand request)
    {
        if (id != request.Id)
            throw new BadRequestException("Id does not match");

        await _mediator.Send(request);
        return Ok(new BaseResult<object>()
        {
            IsSuccess = true
        });
    }
}