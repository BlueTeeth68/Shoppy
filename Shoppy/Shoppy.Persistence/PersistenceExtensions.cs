using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.Persistence.Identity;
using Shoppy.Persistence.Repositories;
using Shoppy.Persistence.Repositories.Base;
using Shoppy.Persistence.Repositories.UnitOfWork;

namespace Shoppy.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<AppDbContext>(options => { options.UseSqlServer(connectionString); });

        //add identity
        services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                options.User.RequireUniqueEmail = true;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            })
            .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        //add repositories
        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>))
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<ICartItemRepository, CartItemRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IOrderItemRepository, OrderItemRepository>()
            .AddScoped<IProductCategoryRepository, ProductCategoryRepository>()
            .AddScoped<IProductRatingRepository, ProductRatingRepository>()
            .AddScoped<IProductRepository, ProductRepository>();

        //unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}