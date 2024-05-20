using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shoppy.Domain.Exceptions.Base;
using Shoppy.SharedLibrary.Models.Base;

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

        var problemDetails = new ProblemDetails
        {
            Detail = exception.Message,
            Instance = null
        };

        problemDetails.Extensions.Add("message", exception.Message);

        if (exception is BaseException ex)
        {
            problemDetails.Status = ex.StatusCode;
            problemDetails.Title = ex.Title;
            problemDetails.Type = ex.Type;
        }
        else if (exception is ValidationException)
        {
            problemDetails.Status = (int)HttpStatusCode.BadRequest;
            problemDetails.Title = "Bad Request";
            problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        }
        else
        {
            problemDetails.Status = (int)HttpStatusCode.InternalServerError;
            problemDetails.Title = "Internal Server Error";
            problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        }

        response.ContentType = "application/problem+json";
        response.StatusCode = problemDetails.Status.Value;

        var result = JsonSerializer.Serialize(new BaseResult<object>()
        {
            IsSuccess = false,
            Error = problemDetails
        });
        await response.WriteAsync(result, cancellationToken: cancellationToken);

        return true;
    }
}