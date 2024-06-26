﻿using Microsoft.AspNetCore.Mvc;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.SharedLibrary.Models.Responses.Products;
using Shoppy.WebMVC.Services.Interfaces.Refit;

namespace Shoppy.WebMVC.Controllers;

public class BooksController(
    ILogger<HomeController> logger,
    ICartsClient cartsClient,
    ICategoriesClient categoriesClient,
    IProductsClient productsClient) : BaseController(logger, cartsClient, categoriesClient)
{
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
            Logger.LogError("Error when fetching home page.\nDate: {}\nDetail: {}", DateTime.UtcNow,
                e.Message);
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Rating(FilterProductRating request)
    {
        if (request.Page == null || request.Size == null)
        {
            request.Page = 1;
            request.Size = 8;
        }

        try
        {
            // var response = await _productService.FilterProductRatingAsync(request);
            var response =
                await productsClient.FilterProductRatingAsync(page: request.Page, size: request.Size,
                    id: request.ProductId);

            if (response == null)
            {
                return Json(new { success = false, error = "Something wrong when fetch product rating" });
            }

            if (!response.IsSuccess)
                return Json(new
                    { success = false, error = response.Error?.Detail ?? "Something wrong when fetch product rating" });

            var data = response.Result;
            return Json(new { success = true, data });
        }
        catch (Exception e)
        {
            Logger.LogError("Error when fetch product rating.\nDate: {}\nDetail: {}", DateTime.UtcNow, e.Message);
            return Json(new { success = false, error = "Something went wrong" });
        }
    }

    [HttpPost]
    public IActionResult _RatingPartial([FromBody] PagingResult<ProductRatingDto> data)
    {
        return View("~/Views/Partial/Books/Review.cshtml", data);
    }

    private async Task<IActionResult?> FetchProductAsync(Guid id)
    {
        // var product = await _productService.GetByIdAsync(id);
        var product = await productsClient.GetByIdAsync(id);
        
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