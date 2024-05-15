using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Shoppy.Application.Features.Products.Requests.Command;

public class CreateProductCommand : IRequest<Guid>
{
    [Required]
    [StringLength(250)]public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    [MaxLength(100)]
    public string Sku { get; set; } = null!;

    [MaxLength(100)]
    public string? AuthorName { get; set; }

    [MaxLength(100)]
    public string? Publisher { get; set; }

    [Range(0, 100000)]
    public int? NumberOfPage { get; set; }

    public DateTime? DateOfPublication { get; set; }

    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    public Guid CategoryId { get; set; }
}