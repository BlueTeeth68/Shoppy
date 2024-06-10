using AutoFixture;
using Moq;
using Shoppy.Application.Features.Authentication.Handlers.Command;
using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Authentication.Handlers.Command;

public class LoginCommandHandlerTest : TestBase
{
    private readonly Mock<IAuthService> _service;
    private readonly LoginCommandHandler _handler;

    public LoginCommandHandlerTest()
    {
        _service = new Mock<IAuthService>();
        _handler = new LoginCommandHandler(_service.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnLoginResponse_WhenCredentialsAreValid()
    {
        // Arrange
        var loginCommand = Fixture.Build<LoginCommand>().Create();

        var expectedLoginResponse = Fixture.Build<LoginResponse>().Create();

        _service.Setup(x => x.LoginAsync(loginCommand))
            .ReturnsAsync(expectedLoginResponse);

        // Act
        var result = await _handler.Handle(loginCommand, CancellationToken.None);

        // Assert
        Assert.Equal(expectedLoginResponse.Id, result.Id);

        _service.Verify(x => x.LoginAsync(loginCommand), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenCredentialsAreInvalid()
    {
        // Arrange
        var loginCommand = Fixture.Build<LoginCommand>().Create();

        _service.Setup(x => x.LoginAsync(loginCommand))
            .ThrowsAsync(new UnauthorizedAccessException("Invalid username or password"));

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _handler.Handle(loginCommand, CancellationToken.None));

        _service.Verify(x => x.LoginAsync(loginCommand), Times.Once);
    }
}