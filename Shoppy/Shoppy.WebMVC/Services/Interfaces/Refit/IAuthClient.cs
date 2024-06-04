using Microsoft.AspNetCore.Mvc;
using Refit;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Auth;
using Shoppy.SharedLibrary.Models.Responses.Auth;

namespace Shoppy.WebMVC.Services.Interfaces.Refit;

public interface IAuthClient
{
    [Post("/auth/login")]
    Task<BaseResult<LoginResultDto>?> LoginAsync([FromBody]LoginDto request);

    [Post("/auth/register")]
    Task<BaseResult<RegisterResultDto>?> RegisterAsync([FromBody]RegisterDto request);
}