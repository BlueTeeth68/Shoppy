using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Requests.Auth;
using Shoppy.SharedLibrary.Models.Responses.Auth;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly AppSettings _appSettings;

    public AuthController(IAuthService authService, AppSettings appSettings)
    {
        _authService = authService;
        _appSettings = appSettings;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Login")]
    public async Task<IActionResult> LoginAsync(LoginDto request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var result = await _authService.LoginAsync(request);

        if (result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return View();
        }

        if (result.IsSuccess)
        {
            if (result.Result == null)
            {
                ViewBag.ErrorMessage = "Something wrong";
                return View();
            }

            var accessTokenCookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(_appSettings.JwtSettings.AccessExpireInMinutes)
            };

            HttpContext.Response.Cookies.Append("email", result.Result.Email ?? "", accessTokenCookieOptions);
            HttpContext.Response.Cookies.Append("accessToken", result.Result.AccessToken,
                accessTokenCookieOptions);
            HttpContext.Response.Cookies.Append("fullName", result.Result.FullName, accessTokenCookieOptions);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = result.Error?.Detail ?? "Something wrong";
        return View(request);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterDto request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var result = await _authService.RegisterAsync(request);

        if (result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return View();
        }

        if (result.IsSuccess)
        {
            if (result.Result == null)
            {
                ViewBag.ErrorMessage = "Something wrong";
                return View();
            }

            await AddResultOptionsAsync(result.Result);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = result.Error?.Detail ?? "Something wrong";
        return View(request);
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("accessToken");
        Response.Cookies.Delete("fullName");
        Response.Cookies.Delete("email");
        return RedirectToAction("Index", "Home");
    }

    private Task AddCookieOptionsAsync(Dictionary<string, object> options, CookieOptions cookieOptions)
    {
        foreach (var option in options)
        {
            HttpContext.Response.Cookies.Append(option.Key, option.Value?.ToString() ?? "", cookieOptions);
        }

        return Task.CompletedTask;
    }

    private async Task AddResultOptionsAsync(RegisterResultDto result)
    {
        var accessTokenCookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddHours(_appSettings.JwtSettings.AccessExpireInMinutes)
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
}