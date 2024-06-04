using Microsoft.AspNetCore.Mvc.Formatters;
using Shoppy.WebMVC;
using Shoppy.WebMVC.Configurations;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

var appSettings = new AppSettings();
configuration.Bind(appSettings);

services.Configure<AppSettings>(configuration);
services.AddSingleton(appSettings);

// Add services to the container.
services.AddControllersWithViews(opt =>
{
    opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
});

services.AddDependency(appSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Exception handler
app.UseExceptionHandler(_ => { });

//custom middleware
app.UseCustomMiddleware();

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();