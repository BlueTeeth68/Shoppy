namespace Shoppy.WebMVC.ExceptionHandlers;

public class UnauthenticatedException: Exception
{
    public UnauthenticatedException(string? message) : base(message)
    {
    }
}