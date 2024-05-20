using Microsoft.AspNetCore.Mvc;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.WebMVC.Models.Auth;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
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
    public async Task<IActionResult> Login(LoginModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var result = await _authService.LoginAsync(request);

        if (result == null)
        {
            request.ErrorMessage = "Something wrong";
            return View();
        }

        if (result.IsSuccess)
        {
            if (result.Result == null)
            {
                request.ErrorMessage = "Something wrong";
                return View();
            }

            request.ErrorMessage = null;
            HttpContext.Session.SetString("fullName", result.Result.FullName);
            HttpContext.Session.SetString("email", result.Result.Email ?? "");
            HttpContext.Session.SetString("accessToken", result.Result.AccessToken);
            return RedirectToPage("/Home");
        }

        request.ErrorMessage = result.Error?.Detail ?? "Something wrong";
        return View(request);
    }

    public IActionResult Register()
    {
        return View();
    }
}