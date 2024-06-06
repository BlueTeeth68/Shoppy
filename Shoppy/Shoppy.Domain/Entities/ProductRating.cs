using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class ProductRating : BaseEntity<Guid>, IAggregateRoot
{
    public int RateValue { get; set; }

    [StringLength(1000)] public string? Comment { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;

    public Guid OrderItemId { get; set; }

    public virtual ICollection<RatingResource> RatingResources { get; set; } = new List<RatingResource>();
}