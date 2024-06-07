using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Products;

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
    public async Task<ActionResult<BaseResult<Guid>>> AddAsync([FromForm] CreateProductCommand request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<Guid>()
        {
            IsSuccess = true,
            Result = data
        };

        return Created(nameof(AddAsync), result);
    }

    [HttpGet]
    public async Task<ActionResult<BaseResult<PagingResult<FilterProductResult>>>> FilterAsync(
        [FromQuery] FilterProductQuery request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<PagingResult<FilterProductResult>>()
        {
            IsSuccess = true,
            Result = data,
        };
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseResult<ProductDetailQueryResult>>> GetByIdAsync([FromRoute] Guid id)
    {
        var data = await _mediator.Send(new GetProductByIdQuery(id));
        var result = new BaseResult<ProductDetailQueryResult>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }

    [HttpGet("{id:guid}/rating")]
    public async Task<ActionResult<BaseResult<PagingResult<ProductRatingDto>>>> FilterProductRatingAsync(
        [FromRoute] Guid id,
        [FromQuery] int? page,
        [FromQuery] int? size)
    {
        var data = await _mediator.Send(new FilterProductRatingQuery()
        {
            ProductId = id,
            Page = page,
            Size = size
        });
        var result = new BaseResult<PagingResult<ProductRatingDto>>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<ActionResult<BaseResult<object>>> UpdateAsync([FromRoute] Guid id,
        [FromForm] UpdateProductCommand request)
    {
        if (id != request.Id)
            throw new BadRequestException("Id do not match");
        await _mediator.Send(request);
        var result = new BaseResult<object>()
        {
            IsSuccess = true,
            Result = null
        };
        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<ActionResult<BaseResult<string>>> UpdateProductThumbAsync(
        [FromForm] UpdateProductImageCommand request)
    {
        var data = await _mediator.Send(request);
        var result = new BaseResult<string>()
        {
            IsSuccess = true,
            Result = data
        };
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = $"{RoleConstant.AdminRole}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        var result = new BaseResult<object>()
        {
            IsSuccess = true,
            Result = null
        };
        return Ok(result);
    }
}