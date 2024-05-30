namespace Shoppy.WebMVC.Middleware;

public class NotFoundMiddleware
{
    private readonly RequestDelegate _next;

    public NotFoundMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == 404)
        {
            const string query =
                "status=404&title='Page not found'&detail='The page you are looking for might have been removed had its name changed or is temporarily unavailable.'";
            context.Response.Redirect(
                $"/error?{query}");
        }
    }
}