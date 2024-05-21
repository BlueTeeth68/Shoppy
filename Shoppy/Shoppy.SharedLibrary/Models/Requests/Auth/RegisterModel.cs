using System.ComponentModel.DataAnnotations;

namespace Shoppy.SharedLibrary.Models.Requests.Auth;

public record RegisterModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [MaxLength(100)]
    public string Email { get; init; } = string.Empty;

    [Required] [MaxLength(50)] public string FullName { get; init; } = string.Empty;

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; init; } = string.Empty;
}