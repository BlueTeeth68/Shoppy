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
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService,
            ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] FilterProductRequest? filter)
        {
            filter ??= new FilterProductRequest()
            {
                Page = 1, Size = 6
            };

            if (filter.Page == null || filter.Size == null)
            {
                filter.Page = 1;
                filter.Size = 6;
            }

            try
            {
                // var categories = await _categoryService.GetAllAsync();
                // if (categories?.Result == null)
                // {
                //     ViewBag.ErrorMessage = "Something wrong";
                //     return View();
                // }
                //
                // if (!categories.IsSuccess)
                // {
                //     ViewBag.ErrorMessage = categories.Error?.Detail ?? "Something wrong";
                //     return View();
                // }
                //
                // ViewBag.Categories = categories.Result;
                //
                // var products = await _productService.FilterProductAsync(filterProduct);
                // if (products?.Result == null)
                // {
                //     ViewBag.ErrorMessage = "Something wrong";
                //     return View();
                // }
                //
                // if (!products.IsSuccess)
                // {
                //     ViewBag.ErrorMessage = products.Error?.Detail ?? "Something wrong";
                //     return View();
                // }
                //
                // ViewBag.Products = products.Result.Results;

                var fetchCategoryTask = FetchCategoriesAsync();
                var fetchProductsTask = FetchProductsAsync(filter);

                await Task.WhenAll(fetchCategoryTask, fetchProductsTask);

                return fetchCategoryTask.Result ?? fetchProductsTask.Result ?? View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error when fetching home page.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                    e.Message);
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<IActionResult?> FetchCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories?.Result == null)
            {
                ViewBag.ErrorMessage = "Something wrong";
                return View();
            }

            if (!categories.IsSuccess)
            {
                ViewBag.ErrorMessage = categories.Error?.Detail ?? "Something wrong";
                return View();
            }

            ViewBag.Categories = categories.Result;
            return null;
        }

        private async Task<IActionResult?> FetchProductsAsync(FilterProductRequest filterProduct)
        {
            var products = await _productService.FilterProductAsync(filterProduct);
            if (products?.Result == null)
            {
                ViewBag.ErrorMessage = "Something wrong";
                return View();
            }

            if (!products.IsSuccess)
            {
                ViewBag.ErrorMessage = products.Error?.Detail ?? "Something wrong";
                return View();
            }

            ViewBag.Products = products.Result.Results;
            return null;
        }
    }
}