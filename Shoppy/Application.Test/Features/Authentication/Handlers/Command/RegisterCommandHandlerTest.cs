using AutoFixture;
using Moq;
using Shoppy.Application.Features.Authentication.Handlers.Command;
using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Authentication.Handlers.Command;

public class RegisterCommandHandlerTest : TestBase
{
    private readonly Mock<IAuthService> _service;
    private readonly RegisterCommandHandler _handler;

    public RegisterCommandHandlerTest()
    {
        _service = new Mock<IAuthService>();
        _handler = new RegisterCommandHandler(_service.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnRegisterResponse_WhenCredentialsAreValid()
    {
        // Arrange
        var registerCommand = Fixture.Build<RegisterCommand>().Create();
        var expectedRegisterResponse = Fixture.Build<RegisterResponse>().Create();

        _service.Setup(x => x.RegisterAsync(registerCommand))
            .ReturnsAsync(expectedRegisterResponse);

        // Act
        var result = await _handler.Handle(registerCommand, CancellationToken.None);

        // Assert
        Assert.Equal(expectedRegisterResponse.Id, result.Id);
        Assert.Equal(expectedRegisterResponse.Email, result.Email);
        Assert.Equal(expectedRegisterResponse.FullName, result.FullName);
        Assert.Equal(expectedRegisterResponse.AccessToken, result.AccessToken);
        Assert.Equal(expectedRegisterResponse.RefreshToken, result.RefreshToken);

        _service.Verify(x => x.RegisterAsync(registerCommand), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenCredentialsAreInvalid()
    {
        // Arrange
        var registerCommand = Fixture.Build<RegisterCommand>().Create();

        _service.Setup(x => x.RegisterAsync(registerCommand))
            .ThrowsAsync(new InvalidOperationException("Unable to register user"));

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _handler.Handle(registerCommand, CancellationToken.None));

        _service.Verify(x => x.RegisterAsync(registerCommand), Times.Once);
    }
}