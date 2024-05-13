using System.Net;
using Shoppy.Domain.Exceptions.Base;

namespace Shoppy.Domain.Exceptions;

public class NotFoundException : BaseException
{
    private const int _statusCode = (int)HttpStatusCode.NotFound;
    private const string? _title = "Not found.";
    private const string? _type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";

    public NotFoundException()
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }

    public NotFoundException(string? message) : base(message)
    {
        StatusCode = _statusCode;
        Title = _title;
        Type = _type;
    }
}