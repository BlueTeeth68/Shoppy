using Moq;
using Shoppy.Application.Features.DataSeeding.Handlers.Command;
using Shoppy.Application.Features.DataSeeding.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.DataSeeding.Handlers.Command;

public class SeedUserCommandHandlerTest
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly SeedUserCommandHandler _handler;

    public SeedUserCommandHandlerTest()
    {
        _userServiceMock = new Mock<IUserService>();
        _handler = new SeedUserCommandHandler(_userServiceMock.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldCallCreateUserDataAsync_WithCorrectParameters()
    {
        // Arrange
        var request = new SeedUserCommand
        {
            Size = 50
        };

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        _userServiceMock.Verify(
            s => s.CreateUserDataAsync(request.Size),
            Times.Once);
    }
}