using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Requests.Auth;
using Shoppy.WebMVC.Services.Interfaces;
using Shoppy.WebMVC.Services.Interfaces.Refit;

namespace Shoppy.WebMVC.Controllers;

public class AuthController : Controller
{
    private readonly IAuthClient _authClient;
    private readonly ITokenManager _tokenManager;

    public AuthController(IAuthClient authClient, ITokenManager tokenManager)
    {
        _authClient = authClient;
        _tokenManager = tokenManager;
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

        var result = await _authClient.LoginAsync(request);

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

            await _tokenManager.AddLoginCookiesAsync(result.Result);

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

        var result = await _authClient.RegisterAsync(request);

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

            await _tokenManager.AddRegisterCookiesAsync(result.Result);

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
        Response.Cookies.Delete("pictureUrl");
        return RedirectToAction("Index", "Home");
    }
}