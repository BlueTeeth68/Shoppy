using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Shoppy.Application.Features.Categories.Requests.Command;

public record CreateCategoryCommand(
    [Required] [MaxLength(50)] string Name,
    [MaxLength(250)] string? Description
) : IRequest<Guid>;