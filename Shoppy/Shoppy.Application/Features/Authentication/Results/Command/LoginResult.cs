namespace Shoppy.Application.Features.Authentication.Results.Command;

public class LoginResult
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? PictureUrl { get; set; }
    public string AccessToken { get; set; } = null!;
}