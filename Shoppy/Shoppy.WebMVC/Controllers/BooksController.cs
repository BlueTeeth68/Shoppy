using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class BooksController : BaseController
{
    private IProductService _productService;

    public BooksController(ILogger<HomeController> logger, ICategoryService categoryService, ICartService cartService,
        IProductService productService) : base(logger, categoryService, cartService)
    {
        _productService = productService;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Detail([FromRoute] Guid id)
    {
        if (id == Guid.Empty)
        {
            return RedirectToAction("Error");
        }

        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();
            var fetchProductTask = FetchProductAsync(id);
            var fetchCartTotalItemTask = FetchCartTotalItemAsync();

            await Task.WhenAll(fetchCategoryTask, fetchProductTask, fetchCartTotalItemTask);

            return fetchCategoryTask.Result ?? fetchProductTask.Result ?? fetchCartTotalItemTask.Result ?? View();
        }
        catch (Exception e)
        {
            _logger.LogError("Error when fetching home page.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    private async Task<IActionResult?> FetchProductAsync(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product?.Result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return View();
        }

        if (!product.IsSuccess)
        {
            ViewBag.ErrorMessage = product.Error?.Detail ?? "Something wrong";
            return View();
        }

        ViewBag.Product = product.Result;
        return null;
    }
}