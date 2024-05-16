using Shoppy.Domain.Constants.Enums;

namespace Shoppy.Application.Features.Products.Results.Query;

public class FilterProductResult
{
    public Guid? Id { get; set; }

    public string? Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ProductThumbUrl { get; set; }

    public decimal? Price { get; set; }

    public decimal? AvgRate { get; set; }

    public int? Quantity { get; set; }

    public int? NumberOfSale { get; set; }

    public ProductStatus? Status { get; set; }
}