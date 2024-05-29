namespace Shoppy.Infrastructure.Configurations;

public class FireBaseSetting
{
    public const string SectionName = "FireBaseSettings";

    public string ApiKey { get; set; } = null!;
    public string Bucket { get; set; } = null!;
    public string AuthEmail { get; set; } = null!;
    public string AuthPassword { get; set; } = null!;
}