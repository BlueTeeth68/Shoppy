using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.WebMVC.Helpers.Utils;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService,
            ICartService cartService, IProductService productService) : base(logger, categoryService, cartService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] FilterProductDto? filter)
        {
            filter ??= new FilterProductDto()
            {
                Page = 1, Size = 6
            };

            if (filter.CategoryId != null)
            {
                ViewBag.CategoryId = filter.CategoryId;
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                ViewBag.Name = filter.Name;
            }

            if (!string.IsNullOrEmpty(filter.SortName))
            {
                ViewBag.SortName = filter.SortName;
            }

            if (!string.IsNullOrEmpty(filter.SortPrice))
            {
                ViewBag.SortName = filter.SortPrice;
            }

            if (filter.Page == null || filter.Size == null)
            {
                filter.Page = 1;
                filter.Size = 8;
            }

            ViewBag.Page = filter.Page;
            ViewBag.Size = filter.Size;

            try
            {
                var fetchCategoryTask = FetchCategoriesAsync();
                var fetchProductsTask = FetchProductsAsync(filter);
                var fetchCartTotalItemTask = FetchCartTotalItemAsync();

                await Task.WhenAll(fetchCategoryTask, fetchProductsTask, fetchCartTotalItemTask);

                return fetchCategoryTask.Result ?? fetchProductsTask.Result ?? View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error when fetching home page.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                    e.Message);
                return RedirectToAction("Error");
            }
        }


        private async Task<IActionResult?> FetchProductsAsync(FilterProductDto filterProduct)
        {
            var products = await _productService.FilterProductAsync(filterProduct);
            if (products?.Result == null)
            {
                ViewBag.ErrorMessage = "Something wrong";
                return RedirectToAction("Error");
            }

            if (!products.IsSuccess)
            {
                ViewBag.ErrorMessage = products.Error?.Detail ?? "Something wrong";
                return RedirectToAction("Error");
            }

            // foreach (var tmp in products.Result.Results)
            // {
            //     tmp.Name = StringUtil.FormatProductName(tmp.Name, 30, 27);
            // }

            ViewBag.Products = products.Result.Results;
            ViewBag.TotalPage = products.Result.TotalPages;
            return null;
        }
    }
}