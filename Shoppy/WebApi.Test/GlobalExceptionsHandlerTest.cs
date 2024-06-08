using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Shoppy.Domain.Exceptions;
using Shoppy.WebAPI.Middlewares.GlobalExceptions;

namespace WebApi.Test;

public class GlobalExceptionsHandlerTest
{
    private readonly HttpContext _context;
    private static Dictionary<string, Exception> _exceptions;

    public GlobalExceptionsHandlerTest()
    {
        _context = new DefaultHttpContext
        {
            Response =
            {
                ContentType = "application/problem+json"
            }
        };

        _exceptions = new Dictionary<string, Exception>()
        {
            { "NotFound", new NotFoundException() },
            { "BadRequest", new BadRequestException() },
            { "Forbidden", new ForbiddenException() },
            { "Conflict", new ConflictException() },
            { "Validation", new ValidationException() },
            { "InternalException", new Exception() }
        };
    }

    [Theory]
    [InlineData("NotFound", "application/problem+json", 404)]
    [InlineData("BadRequest", "application/problem+json", 400)]
    [InlineData("Forbidden", "application/problem+json", 403)]
    [InlineData("Conflict", "application/problem+json", 409)]
    [InlineData("Validation", "application/problem+json", 400)]
    [InlineData("InternalException", "application/problem+json", 500)]
    public async Task TryHandleAsync_ShouldHandleBaseException(string exceptionName, string contentType, int statusCode)
    {
        // Arrange
        var exception = _exceptions[exceptionName];
        var cancellationToken = CancellationToken.None;
        var handler = new GlobalExceptionHandlers();
        // Act
        var handled = await handler.TryHandleAsync(_context, exception, cancellationToken);

        // Assert
        Assert.True(handled);
        Assert.Equal(contentType, _context.Response.ContentType);
        Assert.Equal(statusCode, _context.Response.StatusCode);
    }
}