using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class CartItem : BaseEntity<Guid>, IAggregateRoot
{
    public int Quantity { get; set; }

    public CartItemStatus Status { get; set; }

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}