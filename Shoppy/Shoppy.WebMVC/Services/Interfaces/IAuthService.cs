using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Auth;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface IAuthService
{
    Task<BaseResult<LoginResponse>?> LoginAsync(LoginModel request);

    Task<BaseResult<RegisterResponse>?> RegisterAsync(RegisterModel request);
}