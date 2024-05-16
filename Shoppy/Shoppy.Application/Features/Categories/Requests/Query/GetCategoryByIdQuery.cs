using System.ComponentModel.DataAnnotations;
using MediatR;
using Shoppy.Application.Features.Categories.Results.Query;

namespace Shoppy.Application.Features.Categories.Requests.Query;

public record GetCategoryByIdQuery(
    [Required] Guid Id
) : IRequest<CategoryResult>;