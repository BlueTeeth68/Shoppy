namespace Shoppy.Application.Features.Authentication.Results.Command;

public class RegisterResult
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string AccessToken { get; set; } = null!;
    public string? RefreshToken { get; set; }
}