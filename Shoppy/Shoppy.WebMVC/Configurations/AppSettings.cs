namespace Shoppy.WebMVC.Configurations;

public class AppSettings
{
    public Api Apis { get; set; } = null!;

    public JwtSetting JwtSettings { get; set; } = null!;
}