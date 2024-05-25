using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.ExceptionHandlers;
using Shoppy.WebMVC.Models;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class BaseController : Controller
{
    protected readonly ILogger<HomeController> _logger;
    protected readonly ICategoryService _categoryService;
    protected readonly ICartService _cartService;

    // GET
    public BaseController(ILogger<HomeController> logger, ICategoryService categoryService, ICartService cartService)
    {
        _logger = logger;
        _categoryService = categoryService;
        _cartService = cartService;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    protected async Task<IActionResult?> FetchCategoriesAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        if (categories?.Result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return RedirectToAction("Error");
        }

        if (!categories.IsSuccess)
        {
            ViewBag.ErrorMessage = categories.Error?.Detail ?? "Something wrong";
            // return View();
            return RedirectToAction("Error");
        }

        ViewBag.Categories = categories.Result;
        return null;
    }

    protected async Task<IActionResult?> FetchCartTotalItemAsync()
    {
        var accessToken = HttpContext.Request.Cookies["accessToken"];
        if (string.IsNullOrEmpty(accessToken))
            return null;
        var totalItem = await _cartService.GetCartTotalItemAsync(accessToken);
        if (totalItem?.Result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return RedirectToAction("Error");
        }

        if (!totalItem.IsSuccess)
        {
            ViewBag.ErrorMessage = totalItem.Error?.Detail ?? "Something wrong";
            // return View();
            return RedirectToAction("Error");
        }

        ViewBag.CartTotalItem = totalItem.Result;
        return null;
    }

    protected string GetAccessTokenAsync()
    {
        var accessToken = HttpContext.Request.Cookies["accessToken"];
        if (string.IsNullOrEmpty(accessToken))
        {
            throw new NotLoginException("User do not login");
        }

        return accessToken;
    }
}