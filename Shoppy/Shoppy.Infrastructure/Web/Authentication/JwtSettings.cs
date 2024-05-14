namespace Shoppy.Infrastructure.Web.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    
    public string Key { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int AccessExpireInMinutes { get; set; }
    public int RefreshExpireInDays { get; set; }
}