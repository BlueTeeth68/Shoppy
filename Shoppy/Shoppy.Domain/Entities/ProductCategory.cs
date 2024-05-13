using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class ProductCategory: BaseEntity<Guid>, IAggregateRoot
{
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    [StringLength(250)]
    public string? Description { get; set; } 

}