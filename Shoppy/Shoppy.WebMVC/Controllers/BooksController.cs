using Microsoft.AspNetCore.Mvc;

namespace Shoppy.WebMVC.Controllers;

public class BooksController : Controller
{
    private ILogger<BooksController> _logger;

    public BooksController(ILogger<BooksController> logger)
    {
        _logger = logger;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Detail()
    {
        return View();
    }
}