using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.Models;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class BaseController : Controller
{
    protected readonly ILogger<HomeController> _logger;
    protected readonly ICategoryService _categoryService;

    // GET
    public BaseController(ILogger<HomeController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
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
}