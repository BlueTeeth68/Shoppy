using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Implements;
using Shoppy.WebMVC.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

var appSettings = new AppSettings();
configuration.Bind(appSettings);

services.Configure<AppSettings>(configuration);
services.AddSingleton(appSettings);

// Add services to the container.
services.AddControllersWithViews();

services.AddHttpClient();

//add service
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddScoped<ICartService, CartService>();

//add sesssion
services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();