using System.Net.Http.Headers;
using Newtonsoft.Json;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Carts;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Services.Implements;

public class CartService : ICartService
{
    private readonly HttpClient _client;
    private readonly AppSettings _appSettings;

    private const string BasePath = "users/cart";

    public CartService(AppSettings appSettings, HttpClient client)
    {
        _appSettings = appSettings;
        _client = client;
    }

    public async Task<BaseResult<CartDto>?> GetCartAsync(string? accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_appSettings.Apis.BaseUrl}{BasePath}");

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await _client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<CartDto>>(content);

        return result;
    }

    public async Task<BaseResult<int>?> GetCartTotalItemAsync(string? accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_appSettings.Apis.BaseUrl}{BasePath}/totalItem");

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await _client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<int>>(content);

        return result;
    }
}