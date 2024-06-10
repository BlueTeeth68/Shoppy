using AutoFixture;
using Moq;
using Shoppy.Application.Features.Carts.Handlers.Command;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Carts.Handlers.Command;

public class RemoveCartItemHandlerTest : TestBase
{
    private readonly Mock<IUserService> _serviceMock;
    private readonly RemoveCartItemHandler _handler;

    public RemoveCartItemHandlerTest()
    {
        _serviceMock = new Mock<IUserService>();
        _handler = new RemoveCartItemHandler(_serviceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallRemoveCartItemAsync_WhenRequestIsValid()
    {
        // Arrange
        var removeCartItemCommand = Fixture.Build<RemoveCartItemCommand>().Create();

        // Act
        await _handler.Handle(removeCartItemCommand, CancellationToken.None);

        // Assert
        _serviceMock.Verify(x => x.RemoveCartItemAsync(removeCartItemCommand.ProductId, CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenServiceThrowsException()
    {
        // Arrange
        var removeCartItemCommand = Fixture.Build<RemoveCartItemCommand>().Create();

        _serviceMock.Setup(x => x.RemoveCartItemAsync(removeCartItemCommand.ProductId, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("Unable to remove item from cart"));

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _handler.Handle(removeCartItemCommand, CancellationToken.None));

        _serviceMock.Verify(x => x.RemoveCartItemAsync(removeCartItemCommand.ProductId, CancellationToken.None),
            Times.Once);
    }
}