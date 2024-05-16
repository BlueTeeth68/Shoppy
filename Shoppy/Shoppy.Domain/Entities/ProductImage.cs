using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class ProductImage : BaseEntity<Guid>
{
    [Range(1, 100)] public int Order { get; set; }

    [StringLength(250)] public string ResourceUrl { get; set; } = null!;
    
    public Guid ProductId { get; set; }
}