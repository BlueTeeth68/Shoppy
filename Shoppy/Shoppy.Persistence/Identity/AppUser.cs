using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;

namespace Shoppy.Persistence.Identity;

public class AppUser : IdentityUser<Guid>
{
    [StringLength(100)] public string FullName { get; set; } = string.Empty;

    [StringLength(500)] public string? PictureUrl { get; set; }

    public Gender? Gender { get; set; }

    public UserStatus Status { get; set; }

    public Guid CartId { get; set; }

    public virtual Cart Cart { get; set; } = null!;
}