using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class Product : BaseEntity<Guid>, IAggregateRoot
{
    [StringLength(250)] public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(250)] public string? ProductThumbUrl { get; set; }

    [StringLength(100)] public string Sku { get; set; } = null!;

    public decimal Price { get; set; }

    [Range(0, 5)] public decimal AvgRate { get; set; }

    public int Quantity { get; set; }

    public int NumberOfSale { get; set; }

    public ProductStatus Status { get; set; }

    public Guid CategoryId { get; set; }
    
    public virtual ProductCategory Category { get; set; } = null!;
}