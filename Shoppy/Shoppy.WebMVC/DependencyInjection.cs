using Refit;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Middleware;
using Shoppy.WebMVC.Services.Implements;
using Shoppy.WebMVC.Services.Interfaces;
using Shoppy.WebMVC.Services.Interfaces.Refit;

namespace Shoppy.WebMVC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependency(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddHttpClient();
        services.AddHttpContextAccessor();
        //add service
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITokenManager, TokenManager>();

        //add refit client
        services.AddRefitService(appSettings);

        //add sesssion
        services.AddSession();

        return services;
    }

    public static IServiceCollection AddRefitService(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddTransient<ApiHeaderHandler>();

        var baseApiUri = new Uri($"{appSettings.Apis.BaseUrl}");

        services
            .AddRefitClient<IProductsClient>()
            .AddHttpMessageHandler<ApiHeaderHandler>()
            .ConfigureHttpClient(c => c.BaseAddress = baseApiUri);

        services
            .AddRefitClient<ICategoriesClient>()
            .AddHttpMessageHandler<ApiHeaderHandler>()
            .ConfigureHttpClient(c => c.BaseAddress = baseApiUri);

        services
            .AddRefitClient<IAuthClient>()
            .AddHttpMessageHandler<ApiHeaderHandler>()
            .ConfigureHttpClient(c => c.BaseAddress = baseApiUri);
        
        services
            .AddRefitClient<ICartsClient>()
            .AddHttpMessageHandler<ApiHeaderHandler>()
            .ConfigureHttpClient(c => c.BaseAddress = baseApiUri);
        
        services
            .AddRefitClient<IOrdersClient>()
            .AddHttpMessageHandler<ApiHeaderHandler>()
            .ConfigureHttpClient(c => c.BaseAddress = baseApiUri);

        return services;
    }

    public static WebApplication UseCustomMiddleware(this WebApplication app)
    {
        app.UseMiddleware<LoginMiddleware>();
        app.UseMiddleware<NotFoundMiddleware>();

        return app;
    }
}