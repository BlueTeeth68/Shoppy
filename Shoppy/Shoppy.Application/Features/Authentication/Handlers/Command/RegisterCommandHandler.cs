using MediatR;
using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Authentication.Handlers.Command;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await _authService.RegisterAsync(request);
    }
}