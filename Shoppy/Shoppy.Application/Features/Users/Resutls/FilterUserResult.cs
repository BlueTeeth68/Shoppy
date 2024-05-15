using Shoppy.Domain.Constants.Enums;

namespace Shoppy.Application.Features.Users.Resutls;

public class FilterUserResult
{
    public string FullName { get; set; } = string.Empty;

    public string? PictureUrl { get; set; }

    public Gender? Gender { get; set; }

    public UserStatus Status { get; set; }
    
    public DateTime CreatedDateTime { get; set; }
}