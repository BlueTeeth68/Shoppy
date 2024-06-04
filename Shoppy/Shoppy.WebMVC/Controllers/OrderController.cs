using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Requests.Rating;
using Shoppy.WebMVC.Helpers.Utils;
using Shoppy.WebMVC.Services.Interfaces.Refit;

namespace Shoppy.WebMVC.Controllers;

public class OrderController(
    ILogger<HomeController> logger,
    ICartsClient cartsClient,
    ICategoriesClient categoriesClient,
    IOrdersClient ordersClient) : BaseController(logger, cartsClient, categoriesClient)
{
    // GET
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] int? page, [FromQuery] int? size)
    {
        if (!page.HasValue || !size.HasValue || page.Value <= 0 || size.Value <= 0)
        {
            page = 1;
            size = 10;
        }

        ViewBag.Page = page;
        ViewBag.Size = size;

        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();
            var fetchCartTotalItemTask = FetchCartTotalItemAsync();
            var fetchOrderTask = FetchOrdersAsync(page.Value, size.Value);

            await Task.WhenAll(fetchCategoryTask, fetchOrderTask, fetchCartTotalItemTask);

            return fetchCategoryTask.Result ?? fetchOrderTask.Result ?? fetchCartTotalItemTask.Result ?? View();
        }
        catch (Exception e)
        {
            Logger.LogError("Error when fetching order list.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Detail([FromRoute] Guid id)
    {
        if (id == Guid.Empty)
        {
            return RedirectToAction("Error");
        }

        ViewBag.OrderId = id;

        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();

            var fetchCartTotalItemTask = FetchCartTotalItemAsync();
            var fetchOrderTask = FetchOrderDetailAsync(id);

            await Task.WhenAll(fetchCategoryTask, fetchCartTotalItemTask, fetchOrderTask);

            return fetchCategoryTask.Result ?? fetchOrderTask.Result ?? fetchCartTotalItemTask.Result ?? View();
        }
        catch (Exception e)
        {
            Logger.LogError("Error when fetching order detail.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(AddRatingDto dto, Guid orderId)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Detail", new { id = orderId });
        }

        try
        {
            var result = await AddReviewAsync(dto);
            return result ?? RedirectToAction("Detail", new { id = orderId });
        }
        catch (Exception e)
        {
            Logger.LogError("Error when add review.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    private async Task<IActionResult?> FetchOrdersAsync(int page, int size)
    {
        // var orders = await orderService.FilterUserOrderAsync(page, size, accessToken);

        var orders = await ordersClient.FilterUserOrderAsync(page, size);
        
        if (orders?.Result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return RedirectToAction("Error");
        }

        if (!orders.IsSuccess)
        {
            ViewBag.ErrorMessage = orders.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }

        ViewBag.OrderList = orders.Result.Results;
        ViewBag.TotalPage = orders.Result.TotalPages;
        return null;
    }

    private async Task<IActionResult?> FetchOrderDetailAsync(Guid id)
    {
        // var order = await orderService.GetOrderByIdAsync(id, accessToken);

        var order = await ordersClient.GetOrderByIdAsync(id);
        
        if (order?.Result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return RedirectToAction("Error");
        }

        if (!order.IsSuccess)
        {
            ViewBag.ErrorMessage = order.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }

        foreach (var item in order.Result.Items)
        {
            item.ProductName = StringUtil.FormatProductName(item.ProductName, 40, 37);
        }

        ViewBag.Order = order.Result;
        return null;
    }

    private async Task<IActionResult?> AddReviewAsync(AddRatingDto dto)
    {
        try
        {
            var data = await ordersClient.AddReviewAsync(dto.OrderItemId, dto);
            if (data is not { IsSuccess: false }) return null;

            ViewBag.ErrorMessage = data.Error?.Detail ?? "Something wrong";
            return RedirectToAction("Error");
        }
        catch (Refit.ApiException ex) when (ex.StatusCode is HttpStatusCode.OK or HttpStatusCode.NoContent)
        {
            return null;
        }
    }
}