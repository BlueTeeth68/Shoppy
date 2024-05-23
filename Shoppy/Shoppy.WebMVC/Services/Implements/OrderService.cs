﻿using System.Net.Http.Headers;
using Newtonsoft.Json;
using Shoppy.SharedLibrary.Models.Base;
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
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_appSettings.Apis.BaseUrl}{BasePath}");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await _client.SendAsync(request);

        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<object>>(data);

        return result;
    }
}