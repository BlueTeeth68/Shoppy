using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shoppy.Application.Features.Products.Requests.Command;

public record UpdateProductCommand: IRequest, IRequest<string>
{
    public Guid Id { get; init; }
    
    [StringLength(250)] public string? Name { get; init; }
    
    public IFormFile? ProductThumb { get; set; } 
    
    public string? Description { get; init; }

    [MaxLength(100)] public string? AuthorName { get; init; }

    [MaxLength(100)] public string? Publisher { get; init; }

    [Range(0, 100000)] public int? NumberOfPage { get; init; }

    public DateTime? DateOfPublication { get; init; }

    [Range(0, int.MaxValue)] public decimal? Price { get; init; }

    [Range(0, int.MaxValue)] public int? Quantity { get; init; }

    public Guid? CategoryId { get; init; }
}