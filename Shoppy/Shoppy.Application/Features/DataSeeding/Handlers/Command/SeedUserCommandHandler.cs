using MediatR;
using Shoppy.Application.Features.DataSeeding.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.DataSeeding.Handlers.Command;

public class SeedUserCommandHandler : IRequestHandler<SeedUserCommand>
{
    private readonly IUserService _userService;

    public SeedUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task Handle(SeedUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserDataAsync(request.Size);
    }
}