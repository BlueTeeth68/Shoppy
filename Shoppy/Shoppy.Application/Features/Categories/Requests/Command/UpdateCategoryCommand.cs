using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Shoppy.Application.Features.Categories.Requests.Command;

public record UpdateCategoryCommand(
    Guid Id,
    [MaxLength(50)] string? Name,
    [MaxLength(250)] string? Description
) : IRequest;