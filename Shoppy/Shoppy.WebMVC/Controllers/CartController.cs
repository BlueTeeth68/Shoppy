using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Requests.Carts;
using Shoppy.WebMVC.Helpers.Utils;
using Shoppy.WebMVC.Services.Interfaces.Refit;

namespace Shoppy.WebMVC.Controllers;

public class CartController(
    ILogger<HomeController> logger,
    ICartsClient cartsClient,
    ICategoriesClient categoriesClient,
    IOrdersClient ordersClient) : BaseController(logger, cartsClient, categoriesClient)
{
    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();
            var fetchCartTask = FetchCartAsync();
            var fetchCartTotalItemTask = FetchCartTotalItemAsync();

            await Task.WhenAll(fetchCategoryTask, fetchCartTask, fetchCartTotalItemTask);

            return fetchCategoryTask.Result ?? fetchCartTask.Result ?? fetchCartTotalItemTask.Result ?? View();
        }
        catch (Exception e)
        {
            Logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpPost(Name = "AddToCart")]
    public async Task<IActionResult> AddToCart([FromForm] Guid productId)
    {
        try
        {
            var data = new AddCartItemDto() { ProductId = productId, Quantity = 1 };
            var response = await CartClient.AddToCartAsync(data);

            if (response is { IsSuccess: false })
                return Json(new { success = false, error = response.Error?.Detail ?? "Something wrong" });

            var totalItemResult = await CartClient.GetCartTotalItemAsync();

            var totalItem = totalItemResult?.Result ?? 0;
            return Json(new { success = true, totalItem });
        }
        catch (Refit.ApiException ex) when (ex.StatusCode is HttpStatusCode.Unauthorized)
        {
            const string redirectUrl = "/Auth/Login";
            return Json(new { success = false, redirectUrl });
        }
        catch (Exception e)
        {
            Logger.LogError("Error when adding product to cart.\nDate: {}\nDetail: {}", DateTime.UtcNow, e.Message);
            return Json(new { success = false, error = "Something went wrong" });
        }
    }

    [HttpPost(Name = "RemoveFromCart")]
    public async Task<IActionResult> RemoveFromCart([FromForm] Guid productId)
    {
        try
        {
            var response = await CartClient.RemoveFromCartAsync(productId);

            if (response is not { IsSuccess: false }) return RedirectToAction("Index");
            ViewBag.ErrorMessage = response.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }
        catch (Refit.ApiException ex) when (ex.StatusCode is HttpStatusCode.Unauthorized)
        {
            return RedirectToAction("Login", "Auth");
        }
        catch (Exception e)
        {
            Logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
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

        try
        {
            var response = await CartClient.UpdateCartItemAsync(dto);

            if (response is not { IsSuccess: false }) return RedirectToAction("Index");
            ViewBag.ErrorMessage = response.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }
        catch (Refit.ApiException ex) when (ex.StatusCode is HttpStatusCode.Unauthorized)
        {
            return RedirectToAction("Login", "Auth");
        }
        catch (Exception e)
        {
            Logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CheckOut()
    {
        try
        {
            var response = await ordersClient.CreateOrderAsync();

            if (response is not { IsSuccess: false }) return RedirectToAction("Index", "Order");

            ViewBag.ErrorMessage = response.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }
        catch (Refit.ApiException ex) when (ex.StatusCode is HttpStatusCode.Unauthorized)
        {
            return RedirectToAction("Login", "Auth");
        }
        catch (Exception e)
        {
            Logger.LogError("Error when fetching cart.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    private async Task<IActionResult?> FetchCartAsync()
    {
        try
        {
            var cart = await CartClient.GetCartAsync();
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
        catch (Refit.ApiException ex) when (ex.StatusCode is HttpStatusCode.Unauthorized)
        {
            return RedirectToAction("Login", "Auth");
        }
    }
}