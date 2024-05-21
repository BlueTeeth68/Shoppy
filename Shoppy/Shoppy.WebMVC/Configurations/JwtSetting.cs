namespace Shoppy.WebMVC.Configurations;

public class JwtSetting
{
    public int AccessExpireInMinutes { get; set; }
    public int RefreshExpireInDays { get; set; }
}