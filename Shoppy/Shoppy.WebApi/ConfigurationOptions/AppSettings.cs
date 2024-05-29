using Shoppy.Infrastructure.Configurations;
using Shoppy.Infrastructure.Web.Authentication;

namespace Shoppy.WebAPI.ConfigurationOptions;

public class AppSettings
{
    public ConnectionString ConnectionStrings { get; set; } = null!;

    public JwtSettings JwtSettings { get; set; } = null!;
    // public FireBaseSetting FireBaseSettings { get; set; } = null!;
}