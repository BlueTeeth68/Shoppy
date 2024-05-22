using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class CartController : Controller
{
    private ICategoryService _categoryService;

    public CartController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CheckOut()
    {
        return View();
    }
}

