using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;

namespace Shoppy.Application.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResult> LoginAsync(LoginCommand request);

    Task<RegisterResult> RegisterAsync(RegisterCommand request);
}