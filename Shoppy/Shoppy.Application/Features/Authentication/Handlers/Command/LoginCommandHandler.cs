using MediatR;
using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Authentication.Handlers.Command;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(request);
    }
    
}