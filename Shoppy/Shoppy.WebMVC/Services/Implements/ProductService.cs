using System.Text;
using Newtonsoft.Json;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.SharedLibrary.Models.Responses.Products;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Services.Implements;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private readonly AppSettings _appSettings;
    private const string BasePath = "products";

    public ProductService(HttpClient client, AppSettings appSettings)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _appSettings = appSettings;
    }

    public async Task<BaseResult<PagingResult<FilterProductResultDto>>?> FilterProductAsync(FilterProductDto request)
    {
        request.Status = ProductStatus.Active;
        var queryString = BuildQueryString(request);
        var response = await _client.GetAsync($"{_appSettings.Apis.BaseUrl}{BasePath}?{queryString}");

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<PagingResult<FilterProductResultDto>>>(content);

        return result;
    }

    public async Task<BaseResult<PagingResult<ProductRatingDto>>?> FilterProductRatingAsync(FilterProductRating request)
    {
        var response =
            await _client.GetAsync(
                $"{_appSettings.Apis.BaseUrl}{BasePath}/{request.ProductId}/rating?page={request.Page}&size={request.Size}");

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<PagingResult<ProductRatingDto>>>(content);

        return result;
    }

    public async Task<BaseResult<ProductDto>?> GetByIdAsync(Guid id)
    {
        var response = await _client.GetAsync($"{_appSettings.Apis.BaseUrl}{BasePath}/{id}");

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<ProductDto>>(content);

        return result;
    }

    private string BuildQueryString(FilterProductDto request)
    {
        var queryStringBuilder = new StringBuilder();

        foreach (var property in request.GetType().GetProperties())
        {
            var value = property.GetValue(request);
            if (value == null) continue;

            if (queryStringBuilder.Length > 0)
            {
                queryStringBuilder.Append('&');
            }

            queryStringBuilder.Append(property.Name);
            queryStringBuilder.Append('=');
            queryStringBuilder.Append(Uri.EscapeDataString(value.ToString() ?? string.Empty));
        }

        return queryStringBuilder.ToString();
    }
}