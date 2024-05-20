using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.WebMVC.Models.Auth;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface IAuthService
{
    Task<BaseResult<LoginResult>?> LoginAsync(LoginModel request);
}