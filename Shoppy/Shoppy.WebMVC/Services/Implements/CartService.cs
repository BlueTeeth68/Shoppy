﻿using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Carts;
using Shoppy.SharedLibrary.Models.Responses.Carts;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.ExceptionHandlers;
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
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_appSettings.Apis.BaseUrl}/{BasePath}");

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        else
        {
            throw new UnauthenticatedException("User do not login");
        }

        var response = await _client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<CartDto>>(content);

        return result;
    }

    public async Task<BaseResult<int>?> GetCartTotalItemAsync(string? accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_appSettings.Apis.BaseUrl}/{BasePath}/totalItem");

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        else
        {
            throw new UnauthenticatedException("User do not login");
        }

        var response = await _client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<int>>(content);

        return result;
    }

    public async Task<BaseResult<object>?> AddToCartAsync(Guid productId, string? accessToken)
    {
        var body = new AddCartItemDto
        {
            ProductId = productId,
            Quantity = 1
        };
        var json = JsonConvert.SerializeObject(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(HttpMethod.Post, $"{_appSettings.Apis.BaseUrl}/{BasePath}")
        {
            Content = content
        };

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        else
        {
            throw new UnauthenticatedException("User do not login");
        }

        var response = await _client.SendAsync(request);

        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<object>>(data);

        return result;
    }

    public async Task<BaseResult<object>?> RemoveFromCartAsync(Guid productId, string? accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{_appSettings.Apis.BaseUrl}/{BasePath}/{productId}");

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        else
        {
            throw new UnauthenticatedException("User do not login");
        }

        var response = await _client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<object>>(content);

        return result;
    }

    public async Task<BaseResult<object>?> UpdateCartItemAsync(Guid productId, int quantity, string? accessToken)
    {
        var body = new AddCartItemDto
        {
            ProductId = productId,
            Quantity = quantity
        };
        var json = JsonConvert.SerializeObject(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage(HttpMethod.Patch, $"{_appSettings.Apis.BaseUrl}/{BasePath}/item")
        {
            Content = content
        };

        if (!string.IsNullOrEmpty(accessToken))
        {
            // Add the bearer token to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        else
        {
            throw new UnauthenticatedException("User do not login");
        }

        var response = await _client.SendAsync(request);

        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<object>>(data);

        return result;
    }
}