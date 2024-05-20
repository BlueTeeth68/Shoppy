using System.ComponentModel.DataAnnotations;

namespace Shoppy.WebMVC.Models.Auth;

public class LoginModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = null!;
    
    public string? ErrorMessage { get; set; }
}