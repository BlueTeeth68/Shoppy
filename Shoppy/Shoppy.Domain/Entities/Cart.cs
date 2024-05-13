using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class Cart : IHasKey<Guid>, IAggregateRoot
{
    [Key] public Guid Id { get; set; }

    public int TotalItem { get; set; }

    public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}