using System.Net.Http.Headers;
using Shoppy.WebMVC.Services.Implements;
using Shoppy.WebMVC.Services.Interfaces;

namespace Shoppy.WebMVC.Middleware;

public class ApiHeaderHandler : DelegatingHandler
{
    private readonly ITokenManager _tokenManager;

    public ApiHeaderHandler(ITokenManager tokenManager)
    {
        _tokenManager = tokenManager;
    }

    protected override async Task<HttpResponseMessage>
        SendAsync(HttpRequestMessage request, CancellationToken
            cancellationToken)
    {
        var token = await _tokenManager.GetAccessTokenAsync();
        request.Headers.Authorization = new
            AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, cancellationToken);
    }
}