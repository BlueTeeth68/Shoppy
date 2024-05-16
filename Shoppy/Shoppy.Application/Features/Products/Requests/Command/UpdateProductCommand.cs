﻿using System.ComponentModel.DataAnnotations;

namespace Shoppy.Application.Features.Products.Requests.Command;

public record UpdateProductCommand
{
    public Guid? Id { get; init; }
    
    [StringLength(250)] public string? Name { get; init; }
    
    public string? Description { get; init; }

    [MaxLength(100)] public string? Sku { get; init; }

    [MaxLength(100)] public string? AuthorName { get; init; }

    [MaxLength(100)] public string? Publisher { get; init; }

    [Range(0, 100000)] public int? NumberOfPage { get; init; }

    public DateTime? DateOfPublication { get; init; }

    [Range(0, int.MaxValue)] public decimal? Price { get; init; }

    [Range(0, int.MaxValue)] public int? Quantity { get; init; }

    public Guid? CategoryId { get; init; }
}