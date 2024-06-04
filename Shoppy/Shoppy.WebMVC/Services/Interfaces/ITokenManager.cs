using Shoppy.SharedLibrary.Models.Responses.Auth;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface ITokenManager
{
    Task AddCookieOptionsAsync(Dictionary<string, object> options, CookieOptions cookieOptions);
    Task AddLoginCookiesAsync(LoginResultDto result);
    Task AddRegisterCookiesAsync(RegisterResultDto result);
    Task<string?> GetAccessTokenAsync();
}