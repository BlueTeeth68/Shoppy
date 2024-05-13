using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Domain.Entities;

public class RatingResource : IHasKey<Guid>
{
    [Key] public Guid Id { get; set; }

    [StringLength(500)] public string ResourceUrl { get; set; } = null!;

    [StringLength(250)] public string? Description { get; set; }

    public Guid RatingId { get; set; }

    public virtual ProductRating Rating { get; set; } = null!;
}