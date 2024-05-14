using System.Net;
using Shoppy.Domain.Exceptions.Base;

namespace Shoppy.Domain.Exceptions;

public class BadRequestException: BaseException
{
    private const int _statusCode = (int)HttpStatusCode.BadRequest;
    private const string? _title = "Bad request.";
    private const string? _type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";

    public BadRequestException()
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }

    public BadRequestException(string? message) : base(message)
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }
}