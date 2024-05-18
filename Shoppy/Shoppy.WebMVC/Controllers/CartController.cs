using Microsoft.AspNetCore.Mvc;

namespace Shoppy.WebMVC.Controllers;

public class CartController : Controller
{
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

