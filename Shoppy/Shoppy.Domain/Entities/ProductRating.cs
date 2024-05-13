using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class ProductRating : BaseEntity<Guid>, IAggregateRoot
{
    public int RateValue { get; set; }
    
    [StringLength(250)]
    public string? Comment { get; set; }

    public Guid ProductId { get; set; }
    
    public virtual Product Product { get; set; } = null!;
    
    public Guid UserId { get; set; }
    
}