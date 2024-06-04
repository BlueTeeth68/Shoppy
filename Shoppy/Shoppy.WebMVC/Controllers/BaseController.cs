using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shoppy.SharedLibrary.Models.Error;
using Shoppy.WebMVC.ExceptionHandlers;
using Shoppy.WebMVC.Services.Interfaces.Refit;

namespace Shoppy.WebMVC.Controllers;

public class BaseController(
    ILogger<HomeController> logger,
    ICartsClient cartsClient,
    ICategoriesClient categoriesClient)
    : Controller
{
    protected readonly ILogger<HomeController> Logger = logger;
    protected readonly ICartsClient CartClient = cartsClient;
    protected readonly ICategoriesClient CategoriesClient = categoriesClient;

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        var model = new ErrorModel { Status = 500, Title = "Something wrong", Detail = "Something wrong" };
        return RedirectToAction("Index", "Error", model);
    }

    protected async Task<IActionResult?> FetchCategoriesAsync()
    {
        var categories = await CategoriesClient.GetAllAsync();
        if (categories?.Result == null)
        {
            ViewBag.ErrorMessage = "Something wrong";
            return RedirectToAction("Error");
        }

        if (!categories.IsSuccess)
        {
            ViewBag.ErrorMessage = categories.Error?.Detail ?? "Something wrong";
            // return View();
            return RedirectToAction("Error");
        }

        ViewBag.Categories = categories.Result;
        return null;
    }

    protected async Task<IActionResult?> FetchCartTotalItemAsync()
    {
        try
        {
            var totalItem = await CartClient.GetCartTotalItemAsync();
            if (totalItem?.Result == null)
            {
                ViewBag.ErrorMessage = "Something wrong";
                return RedirectToAction("Error");
            }

            if (!totalItem.IsSuccess)
            {
                ViewBag.ErrorMessage = totalItem.Error?.Detail ?? "Something wrong";
                // return View();
                return RedirectToAction("Error");
            }

            ViewBag.CartTotalItem = totalItem.Result;
            return null;
        }
        catch (Refit.ApiException ex) when (ex.StatusCode is HttpStatusCode.NoContent or HttpStatusCode.Unauthorized)
        {
            return null;
        }
    }

    protected string GetAccessTokenAsync()
    {
        var accessToken = HttpContext.Request.Cookies["accessToken"];
        if (string.IsNullOrEmpty(accessToken))
        {
            throw new NotLoginException("User do not login");
        }
        return accessToken;
    }
}