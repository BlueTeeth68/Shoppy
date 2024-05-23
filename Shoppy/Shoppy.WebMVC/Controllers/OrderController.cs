﻿using Microsoft.AspNetCore.Mvc;
using Shoppy.WebMVC.Helpers.Utils;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Controllers;

public class OrderController : BaseController
{
    private readonly IOrderService _orderService;

    public OrderController(ILogger<HomeController> logger, ICategoryService categoryService, ICartService cartService,
        IOrderService orderService) :
        base(logger, categoryService, cartService)
    {
        _orderService = orderService;
    }

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

        var accessToken = HttpContext.Request.Cookies["accessToken"];
        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();
            var fetchCartTotalItemTask = FetchCartTotalItemAsync();
            var fetchOrderTask = FetchOrdersAsync(page.Value, size.Value, accessToken);

            await Task.WhenAll(fetchCategoryTask, fetchOrderTask, fetchCartTotalItemTask);

            return fetchCategoryTask.Result ?? fetchOrderTask.Result ?? fetchCartTotalItemTask.Result ?? View();
        }
        catch (Exception e)
        {
            _logger.LogError("Error when fetching order list.\nDate: {}\nDetail: {}", DateTime.UtcNow,
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

        var accessToken = HttpContext.Request.Cookies["accessToken"];

        try
        {
            var fetchCategoryTask = FetchCategoriesAsync();

            var fetchCartTotalItemTask = FetchCartTotalItemAsync();
            var fetchOrderTask = FetchOrderDetailAsync(id, accessToken);

            await Task.WhenAll(fetchCategoryTask, fetchCartTotalItemTask, fetchOrderTask);

            return fetchCategoryTask.Result ?? fetchOrderTask.Result ?? fetchCartTotalItemTask.Result ?? View();
        }
        catch (Exception e)
        {
            _logger.LogError("Error when fetching order detail.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    private async Task<IActionResult?> FetchOrdersAsync(int page, int size, string? accessToken)
    {
        var orders = await _orderService.FilterUserOrderAsync(page, size, accessToken);
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

    private async Task<IActionResult?> FetchOrderDetailAsync(Guid id, string? accessToken)
    {
        var order = await _orderService.GetOrderByIdAsync(id, accessToken);
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
}