using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Shoppy.Application.Features.DataSeeding.Requests.Command;

public class SeedProductCommand: IRequest
{
    [Range(1, 10000)]
    [Required]
    public int Size { get; set; }
    
    public Guid CategoryId { get; set; }
}