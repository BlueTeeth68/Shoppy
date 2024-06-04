using Newtonsoft.Json;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Categories;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Services.Implements;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _client;
    private readonly AppSettings _appSettings;
    private const string BasePath = "categories";

    public CategoryService(HttpClient client, AppSettings appSettings)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _appSettings = appSettings;
    }

    public async Task<BaseResult<List<CategoryDto>>?> GetAllAsync()
    {
        var response = await _client.GetAsync($"{_appSettings.Apis.BaseUrl}/{BasePath}");

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<List<CategoryDto>>>(content);

        return result;
    }
}