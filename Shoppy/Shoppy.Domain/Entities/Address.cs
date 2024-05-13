using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class Address : BaseEntity<Guid>, IAggregateRoot
{
    [StringLength(11)] public string? PhoneNumber { get; set; }

    [StringLength(500)]
    public string Detail { get; set; } = null!;
    
    public bool IsDefault { get; set; }

    public Guid UserId { get; set; }
}