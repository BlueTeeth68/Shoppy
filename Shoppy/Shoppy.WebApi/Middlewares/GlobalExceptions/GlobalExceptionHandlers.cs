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

        switch (exception)
        {
            case BaseException ex:
                problemDetails.Status = ex.StatusCode;
                problemDetails.Title = ex.Title;
                problemDetails.Type = ex.Type;
                break;
            case ValidationException:
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                problemDetails.Title = "Bad Request";
                problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                break;
            default:
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                problemDetails.Title = "Internal Server Error";
                problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                break;
        }

        response.ContentType = "application/problem+json";
        response.StatusCode = problemDetails.Status.Value;

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var result = JsonSerializer.Serialize(new BaseResult<object>()
        {
            IsSuccess = false,
            Error = problemDetails
        }, options);
        await response.WriteAsync(result, cancellationToken: cancellationToken);

        return true;
    }
}