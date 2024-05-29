using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shoppy.Application.Features.Products.Requests.Command;

public class CreateProductCommand : IRequest<Guid>
{
    [Required]
    [StringLength(250)]public string Name { get; init; } = null!;

    public string? Description { get; init; }

    [Required]
    public IFormFile ProductThumb { get; init; } = null!;
    
    [MaxLength(100)]
    public string? AuthorName { get; init; }

    [MaxLength(100)]
    public string? Publisher { get; init; }

    [Range(0, 100000)]
    public int? NumberOfPage { get; init; }

    public DateTime? DateOfPublication { get; init; }

    [Range(0, int.MaxValue)]
    public decimal Price { get; init; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; init; }

    [Required]
    public Guid CategoryId { get; init; }
}