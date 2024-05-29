using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Infrastructure.Authentication;
using Shoppy.Infrastructure.Configurations;
using Shoppy.Infrastructure.Services;
using Shoppy.Infrastructure.Web.Authentication;

namespace Shoppy.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.Configure<FireBaseSetting>(configuration.GetSection(FireBaseSetting.SectionName));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IFileService, FileService>();

        return services;
    }
}