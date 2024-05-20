using Newtonsoft.Json;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.WebMVC.Models.Auth;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Services.Implements;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;

    public AuthService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public const string BasePath = "https://localhost:44301/api/v1/auth/";

    public async Task<BaseResult<LoginResult>?> LoginAsync(LoginModel request)
    {
        var response = await _client.PostAsJsonAsync($"{BasePath}login", request);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseResult<LoginResult>>(content);

        return result;
    }
}