using System.Text;
using Newtonsoft.Json;
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

    public async Task<BaseResult<PagingResult<FilterProductResponse>>?> FilterProductAsync(FilterProductRequest request)
    {
        var queryString = BuildQueryString(request);
        var response = await _client.GetAsync($"{_appSettings.Apis.BaseUrl}{BasePath}?{queryString}");

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<PagingResult<FilterProductResponse>>>(content);

        return result;
    }

    private string BuildQueryString(FilterProductRequest request)
    {
        var queryStringBuilder = new StringBuilder();

        foreach (var property in request.GetType().GetProperties())
        {
            var value = property.GetValue(request);
            if (value != null)
            {
                if (queryStringBuilder.Length > 0)
                {
                    queryStringBuilder.Append("&");
                }

                queryStringBuilder.Append(property.Name);
                queryStringBuilder.Append("=");
                queryStringBuilder.Append(Uri.EscapeDataString(value.ToString()));
            }
        }

        return queryStringBuilder.ToString();
    }
}