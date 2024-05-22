using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class Cart : BaseEntity<Guid>, IAggregateRoot
{
    public int TotalItem { get; set; }

    public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}