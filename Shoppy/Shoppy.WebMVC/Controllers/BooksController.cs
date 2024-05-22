using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.Models;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class BooksController : Controller
{
    private ILogger<BooksController> _logger;
    private ICategoryService _categoryService;
    private IProductService _productService;

    public BooksController(ILogger<BooksController> logger, ICategoryService categoryService,
        IProductService productService)
    {
        _logger = logger;
        _categoryService = categoryService;
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

            await Task.WhenAll(fetchCategoryTask, fetchProductTask);

            return fetchCategoryTask.Result ?? fetchProductTask.Result ?? View();
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