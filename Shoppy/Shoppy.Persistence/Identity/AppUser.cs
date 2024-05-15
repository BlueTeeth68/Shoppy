using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Entities.Base;

namespace Shoppy.Persistence.Identity;

public class AppUser : IdentityUser<Guid>, ITrackable
{
    [StringLength(100)] public string FullName { get; set; } = string.Empty;

    [StringLength(500)] public string? PictureUrl { get; set; }

    public Gender? Gender { get; set; }

    public UserStatus Status { get; set; }
    
    public bool IsDelete { get; set; }

    public Guid? CartId { get; set; }

    public virtual Cart? Cart { get; set; }

    [Timestamp] public byte[] RowVersion { get; set; } = null!;
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDateTime { get; set; }
}