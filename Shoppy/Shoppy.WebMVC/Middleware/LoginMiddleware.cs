using Shoppy.WebMVC.ExceptionHandlers;

namespace Shoppy.WebMVC.Middleware;

public class LoginMiddleware
{
    private readonly RequestDelegate _next;

    public LoginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotLoginException)
        {
            context.Response.Redirect("/Auth/Login");
        }
    }
}