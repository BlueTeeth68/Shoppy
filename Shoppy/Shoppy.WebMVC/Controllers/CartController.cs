using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.Helpers.Utils;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class CartController : BaseController
{
    private readonly ICartService _cartService;

    public CartController(ILogger<HomeController> logger, ICategoryService categoryService, ICartService cartService) :
        base(logger, categoryService)
    {
        _cartService = cartService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var accessToken = HttpContext.Request.Cookies["accessToken"];

        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();
            var fetchCartTask = FetchCartAsync(accessToken);

            await Task.WhenAll(fetchCategoryTask, fetchCartTask);

            return fetchCategoryTask.Result ?? fetchCartTask.Result ?? View();
        }
        catch (Exception e)
        {
            _logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    public IActionResult CheckOut()
    {
        return View();
    }

    private async Task<IActionResult?> FetchCartAsync(string? accessToken)
    {
        var cart = await _cartService.GetCartAsync(accessToken);
        if (cart?.Result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return RedirectToAction("Error");
        }

        if (!cart.IsSuccess)
        {
            ViewBag.ErrorMessage = cart.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }

        foreach (var item in cart.Result.Items)
        {
            item.ProductName = StringUtil.FormatProductName(item.ProductName, 40, 37);
        }

        ViewBag.Cart = cart.Result;
        return null;
    }
}