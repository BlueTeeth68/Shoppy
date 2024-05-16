using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Exceptions;

namespace Shoppy.WebAPI.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductCommand request)
    {
        var result = await _mediator.Send(request);

        return Created(nameof(AddAsync), result);
    }

    [HttpGet]
    public async Task<IActionResult> FilterAsync([FromQuery] FilterProductQuery request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductCommand request)
    {
        if (id != request.Id)
            throw new BadRequestException("Id do not match");
        await _mediator.Send(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
}