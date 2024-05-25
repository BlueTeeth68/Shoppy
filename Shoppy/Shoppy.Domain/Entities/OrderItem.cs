using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class OrderItem : BaseEntity<Guid>, IAggregateRoot
{
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public bool IsReviewed { get; set; }

    public virtual ProductRating? ProductRating { get; set; }

    public virtual Order Order { get; set; } = null!;
}