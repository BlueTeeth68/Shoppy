using Microsoft.AspNetCore.Mvc;

namespace Shoppy.WebMVC.Controllers;

public class OrderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}