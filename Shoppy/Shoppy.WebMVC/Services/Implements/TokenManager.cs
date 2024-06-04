using Shoppy.SharedLibrary.Models.Responses.Auth;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Services.Implements;

public class TokenManager : ITokenManager
{
    private readonly IHttpContextAccessor  _httpContextAccessor;
    private readonly AppSettings _appSettings;


    public TokenManager(IHttpContextAccessor httpContextAccessor, AppSettings appSettings)
    {
        _httpContextAccessor = httpContextAccessor;
        _appSettings = appSettings;
    }

    public Task AddCookieOptionsAsync(Dictionary<string, object> options, CookieOptions cookieOptions)
    {
        foreach (var option in options)
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(option.Key, option.Value.ToString() ?? "", cookieOptions);
        }

        return Task.CompletedTask;
    }

    public async Task AddLoginCookiesAsync(LoginResultDto result)
    {
        var accessTokenCookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.AccessExpireInMinutes)
        };

        var accessOptions = new Dictionary<string, object>()
        {
            { "email", result.Email ?? "" },
            { "accessToken", result.AccessToken },
            { "fullName", result.FullName },
            { "pictureUrl", result.PictureUrl ?? "" }
        };

        await AddCookieOptionsAsync(accessOptions, accessTokenCookieOptions);
    }

    public async Task AddRegisterCookiesAsync(RegisterResultDto result)
    {
        var accessTokenCookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.AccessExpireInMinutes)
        };

        var refreshTokenCookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(_appSettings.JwtSettings.RefreshExpireInDays)
        };

        var accessOptions = new Dictionary<string, object>()
        {
            { "email", result.Email ?? "" },
            { "accessToken", result.AccessToken },
            { "fullName", result.FullName }
        };

        var refreshOptions = new Dictionary<string, object>()
        {
            { "refreshToken", result.RefreshToken ?? "" }
        };

        var accessTask = AddCookieOptionsAsync(accessOptions, accessTokenCookieOptions);
        var refreshTask = AddCookieOptionsAsync(refreshOptions, refreshTokenCookieOptions);
        await Task.WhenAll(accessTask, refreshTask);
    }

    public Task<string?> GetAccessTokenAsync()
    {
        var accessToken = _httpContextAccessor.HttpContext?.Request.Cookies["accessToken"];

        return Task.FromResult(accessToken);
    }
}