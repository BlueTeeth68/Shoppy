using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shoppy.Application.Features.Products.Requests.Command;

public class UpdateProductImageCommand : IRequest<string>
{
    [Required] public Guid Id { get; init; }
    [Required] public IFormFile File { get; init; } = null!;
}