using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Error;

namespace Shoppy.WebMVC.Controllers;

public class ErrorController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index(ErrorModel? errorModel)
    {
        errorModel ??= new ErrorModel { Status = 500, Title = "Something wrong", Detail = "Something wrong" };

        ViewBag.Title = errorModel.Status switch
        {
            500 => "500 Something wrong",
            404 => "404 Page not found",
            _ => "500 Something wrong"
        };
        return View(errorModel);
    }
}