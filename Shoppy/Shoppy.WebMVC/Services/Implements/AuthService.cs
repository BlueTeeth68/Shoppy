using Newtonsoft.Json;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Auth;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Services.Implements;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;
    private readonly AppSettings _appSettings;
    private const string BasePath = "auth/";

    public AuthService(HttpClient client, AppSettings appSettings)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _appSettings = appSettings;
    }

    public async Task<BaseResult<LoginResponse>?> LoginAsync(LoginDto request)
    {
        var response = await _client.PostAsJsonAsync($"{_appSettings.Apis.BaseUrl}{BasePath}login", request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<LoginResponse>>(content);

        return result;
    }

    public async Task<BaseResult<RegisterResponse>?> RegisterAsync(RegisterDto request)
    {
        var response = await _client.PostAsJsonAsync($"{_appSettings.Apis.BaseUrl}{BasePath}register", request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<RegisterResponse>>(content);

        return result;
    }
    
    
}