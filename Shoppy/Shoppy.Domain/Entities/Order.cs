using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class Order : BaseEntity<Guid>, IAggregateRoot
{
    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Success;

    public Guid UserId { get; set; }

    public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}