using Shoppy.Application;
using Shoppy.Domain.Identity;
using Shoppy.Infrastructure;
using Shoppy.Infrastructure.Identity;
using Shoppy.Persistence;
using Shoppy.WebAPI;
using Shoppy.WebAPI.ConfigurationOptions;
using Shoppy.WebAPI.Middlewares.GlobalExceptions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

var appSettings = new AppSettings();
configuration.Bind(appSettings);

services.Configure<AppSettings>(configuration);

services.AddApplication()
    .AddInfrastructure(configuration)
    .AddPersistence(appSettings.ConnectionStrings.DefaultConnection)
    .AddPresentation(appSettings.JwtSettings);

services.AddExceptionHandler<GlobalExceptionHandlers>();

services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddScoped<ICurrentUser, CurrentUser>();

var app = builder.Build();

//use Global exception
app.UseExceptionHandler(_ => { });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("public_policy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();