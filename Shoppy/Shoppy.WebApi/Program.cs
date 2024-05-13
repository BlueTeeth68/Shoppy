using Shoppy.Persistence;
using Shoppy.WebAPI.ConfigurationOptions;
using Shoppy.WebAPI.Middlewares.GlobalExceptions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

var appSettings = new AppSettings();
configuration.Bind(appSettings);

services.Configure<AppSettings>(configuration);


//add persistence
services.AddPersistence(appSettings.ConnectionStrings.DefaultConnection);

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddExceptionHandler<GlobalExceptionHandlers>();

var app = builder.Build();

//use Global exception
app.UseExceptionHandler(options => { });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();