using System.Net;
using Shoppy.Domain.Exceptions.Base;

namespace Shoppy.Domain.Exceptions;

public class ConflictException: BaseException
{
    private const int _statusCode = (int)HttpStatusCode.Conflict;
    private const string? _title = "Resource conflict.";
    private const string? _type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";

    public ConflictException()
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }

    public ConflictException(string? message) : base(message)
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }
}