using Microsoft.AspNetCore.Diagnostics;
using Shoppy.WebMVC.ExceptionHandlers;

namespace Shoppy.WebMVC.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is UnauthenticatedException)
        {
            httpContext.Response.Redirect("/Auth/Login");
        }

        return await Task.FromResult(true);
    }
}