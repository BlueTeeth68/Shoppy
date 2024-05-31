using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Requests.Carts;
using Shoppy.WebMVC.Helpers.Utils;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class CartController : BaseController
{
    private readonly IOrderService _orderService;

    public CartController(ILogger<HomeController> logger, ICategoryService categoryService, ICartService cartService,
        IOrderService orderService) :
        base(logger, categoryService, cartService)
    {
        _orderService = orderService;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accessToken = GetAccessTokenAsync();

        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();
            var fetchCartTask = FetchCartAsync(accessToken);
            var fetchCartTotalItemTask = FetchCartTotalItemAsync();

            await Task.WhenAll(fetchCategoryTask, fetchCartTask, fetchCartTotalItemTask);

            return fetchCategoryTask.Result ?? fetchCartTask.Result ?? fetchCartTotalItemTask.Result ?? View();
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
        // var accessToken = GetAccessTokenAsync();

        var accessToken = HttpContext.Request.Cookies["accessToken"];
        if (string.IsNullOrEmpty(accessToken))
        {
            const string redirectUrl = "/Auth/Login";
            return Json(new { success = false, redirectUrl });
        }

        try
        {
            var response = await _cartService.AddToCartAsync(productId, accessToken);

            if (response != null)
                return Json(new { success = false, error = response.Error?.Detail ?? "Something wrong" });
            
            var totalItemResult = await _cartService.GetCartTotalItemAsync(accessToken);

            var totalItem = totalItemResult?.Result ?? 0;
            return Json(new { success = true, totalItem });

        }
        catch (Exception e)
        {
            _logger.LogError("Error when adding product to cart.\nDate: {}\nDetail: {}", DateTime.UtcNow, e.Message);
            return Json(new { success = false, error = "Something went wrong" });
        }
    }

    [HttpPost(Name = "RemoveFromCart")]
    public async Task<IActionResult> RemoveFromCart([FromForm] Guid productId)
    {
        var accessToken = GetAccessTokenAsync();

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

        var accessToken = GetAccessTokenAsync();

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


    [HttpPost]
    public async Task<IActionResult> CheckOut()
    {
        var accessToken = GetAccessTokenAsync();

        try
        {
            var response = await _orderService.CreateOrderAsync(accessToken);
            if (response == null || response.IsSuccess) return RedirectToAction("Index");

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