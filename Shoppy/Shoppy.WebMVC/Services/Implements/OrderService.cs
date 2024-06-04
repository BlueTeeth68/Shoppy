using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Rating;
using Shoppy.SharedLibrary.Models.Responses.Orders;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Services.Implements;

public class OrderService : IOrderService
{
    private readonly HttpClient _client;
    private readonly AppSettings _appSettings;
    private const string BasePath = "orders";

    public OrderService(HttpClient client, AppSettings appSettings)
    {
        _client = client;
        _appSettings = appSettings;
    }

    public async Task<BaseResult<object>?> CreateOrderAsync(string? accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_appSettings.Apis.BaseUrl}/{BasePath}");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await _client.SendAsync(request);

        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<object>>(data);

        return result;
    }

    public async Task<BaseResult<PagingResult<OrderQueryDto>>?> FilterUserOrderAsync(int page, int size,
        string? accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"{_appSettings.Apis.BaseUrl}/{BasePath}/account?page={page}&size={size}");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await _client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<PagingResult<OrderQueryDto>>>(content);

        return result;
    }

    public async Task<BaseResult<OrderDto>?> GetOrderByIdAsync(Guid id, string? accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_appSettings.Apis.BaseUrl}/{BasePath}/{id}");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await _client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<OrderDto>>(content);

        return result;
    }

    public async Task<BaseResult<object>?> AddReviewAsync(AddRatingDto dto, string? accessToken)
    {
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(HttpMethod.Post,
            $"{_appSettings.Apis.BaseUrl}/{BasePath}/{dto.OrderItemId}/rating")
        {
            Content = content
        };

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await _client.SendAsync(request);

        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<object>>(data);

        return result;
    }
}