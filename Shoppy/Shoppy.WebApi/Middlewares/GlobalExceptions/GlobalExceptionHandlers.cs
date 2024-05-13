using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Domain.Exceptions.Base;

namespace Shoppy.WebAPI.Middlewares.GlobalExceptions;

public class GlobalExceptionHandlers : IExceptionHandler
{
    public GlobalExceptionHandlers()
    {
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var response = httpContext.Response;

        if (exception is BaseException ex)
        {
            var problemDetails = new ProblemDetails
            {
                Detail = ex.Message,
                Instance = null,
                Status = ex.StatusCode,
                Title = ex.Title,
                Type = ex.Type
            };

            problemDetails.Extensions.Add("message", ex.Message);

            response.ContentType = "application/problem+json";
            response.StatusCode = problemDetails.Status.Value;

            var result = JsonSerializer.Serialize(problemDetails);
            await response.WriteAsync(result, cancellationToken: cancellationToken);

            return true;
        }
        else if (exception is ValidationException)
        {
            var problemDetails = new ProblemDetails
            {
                Detail = exception.Message,
                Instance = null,
                Status = (int)HttpStatusCode.BadRequest,
                Title = "Bad Request",
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
            };

            problemDetails.Extensions.Add("message", exception.Message);

            response.ContentType = "application/problem+json";
            response.StatusCode = problemDetails.Status.Value;

            var result = JsonSerializer.Serialize(problemDetails);
            await response.WriteAsync(result, cancellationToken: cancellationToken);

            return true;
        }
        else
        {
            var problemDetails = new ProblemDetails
            {
                Detail = exception.Message,
                Instance = null,
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Internal Server Error",
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            };

            problemDetails.Extensions.Add("message", exception.Message);

            response.ContentType = "application/problem+json";
            response.StatusCode = problemDetails.Status.Value;

            var result = JsonSerializer.Serialize(problemDetails);
            await response.WriteAsync(result, cancellationToken: cancellationToken);

            return true;
        }
    }
}