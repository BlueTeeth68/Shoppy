namespace Shoppy.WebMVC.ExceptionHandlers;

public class NotLoginException: Exception
{
    public NotLoginException(string? message) : base(message)
    {
    }
}