﻿using System.Collections.ObjectModel;
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

    [StringLength(100)] public string? AuthorName { get; set; }

    [StringLength(100)] public string? Publisher { get; set; }

    [Range(0, 100000)] public int? NumberOfPage { get; set; }

    public DateTime? DateOfPublication { get; set; }

    [Range(0, int.MaxValue)] public decimal Price { get; set; }

    [Range(0, 5)] public decimal? AvgRate { get; set; }

    [Range(0, int.MaxValue)] public int Quantity { get; set; }

    public int NumberOfSale { get; set; }

    public ProductStatus Status { get; set; } = ProductStatus.Active;

    public bool IsDelete { get; set; }

    public Guid CategoryId { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

    public virtual ICollection<OrderItem> OrderDetails { get; set; } = new List<OrderItem>();
}