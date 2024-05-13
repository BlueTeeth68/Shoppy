using System.ComponentModel.DataAnnotations;

namespace Shoppy.Domain.Entities.Base;

public abstract class BaseEntity<TKey> : IHasKey<TKey>, ITrackable
{
    [Key] public TKey Id { get; set; } 

    [Timestamp] public byte[] RowVersion { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }
}