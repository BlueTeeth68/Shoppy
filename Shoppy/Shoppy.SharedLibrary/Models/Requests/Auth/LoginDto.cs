using System.ComponentModel.DataAnnotations;

namespace Shoppy.SharedLibrary.Models.Requests.Auth;

public record LoginDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; init; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; init; } = null!;
}