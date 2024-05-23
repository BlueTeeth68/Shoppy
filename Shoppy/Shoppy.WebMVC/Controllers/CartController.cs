using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Requests.Carts;
using Shoppy.WebMVC.Helpers.Utils;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class CartController : BaseController
{
    public CartController(ILogger<HomeController> logger, ICategoryService categoryService, ICartService cartService) :
        base(logger, categoryService, cartService)
    {
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accessToken = HttpContext.Request.Cookies["accessToken"];

        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();
            var fetchCartTask = FetchCartAsync(accessToken);
            var fetchCartTotalItemTask = FetchCartTotalItemAsync();

            await Task.WhenAll(fetchCategoryTask, fetchCartTask, fetchCartTotalItemTask);

            return fetchCategoryTask.Result ?? fetchCartTask.Result ?? View();
        }
        catch (Exception e)
        {
            _logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpPost(Name = "AddToCart")]
    public async Task<IActionResult> AddToCart([FromForm] Guid productId)
    {
        var accessToken = HttpContext.Request.Cookies["accessToken"];

        try
        {
            var response = await _cartService.AddToCartAsync(productId, accessToken);
            if (response == null) return RedirectToAction("Index");

            ViewBag.ErrorMessage = response.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }
        catch (Exception e)
        {
            _logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpPost(Name = "RemoveFromCart")]
    public async Task<IActionResult> RemoveFromCart([FromForm] Guid productId)
    {
        var accessToken = HttpContext.Request.Cookies["accessToken"];

        try
        {
            var response = await _cartService.RemoveFromCartAsync(productId, accessToken);
            if (response == null) return RedirectToAction("Index");

            ViewBag.ErrorMessage = response.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }
        catch (Exception e)
        {
            _logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpPost(Name = "UpdateCartItem")]
    public async Task<IActionResult> UpdateCartItem([FromForm] UpdateCartItemDto dto)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", dto);
        }

        var accessToken = HttpContext.Request.Cookies["accessToken"];

        try
        {
            var response = await _cartService.UpdateCartItemAsync(dto.ProductId, dto.Quantity, accessToken);
            if (response == null) return RedirectToAction("Index");

            ViewBag.ErrorMessage = response.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
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