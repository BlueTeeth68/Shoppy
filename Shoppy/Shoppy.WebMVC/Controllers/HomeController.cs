using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.Models;
using System.Diagnostics;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var filterProduct = new FilterProductRequest()
            {
                Page = 1, Size = 6
            };

            try
            {
                var result = await _productService.FilterProductAsync(filterProduct);
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

                    ViewBag.Products = result.Result.Results;
                    return View();
                }

                ViewBag.ErrorMessage = result.Error?.Detail ?? "Something wrong";

                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}