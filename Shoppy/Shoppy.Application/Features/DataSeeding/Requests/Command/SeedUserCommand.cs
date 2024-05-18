using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Shoppy.Application.Features.DataSeeding.Requests.Command;

public class SeedUserCommand : IRequest
{
    [Range(1, 100000)]
    [Required]
    public int Size { get; set; }
}