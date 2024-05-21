using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;

namespace Shoppy.Application.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginCommand request);

    Task<RegisterResponse> RegisterAsync(RegisterCommand request);
}