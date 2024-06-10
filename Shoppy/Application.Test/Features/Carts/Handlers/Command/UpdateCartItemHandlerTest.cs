using AutoFixture;
using Moq;
using Shoppy.Application.Features.Carts.Handlers.Command;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Carts.Handlers.Command;

public class UpdateCartItemHandlerTest : TestBase
{
    private readonly Mock<IUserService> _serviceMock;
    private readonly UpdateCartItemHandler _handler;

    public UpdateCartItemHandlerTest()
    {
        _serviceMock = new Mock<IUserService>();
        _handler = new UpdateCartItemHandler(_serviceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallUpdateCartItemAsync_WhenRequestIsValid()
    {
        // Arrange
        var updateCartItemCommand = Fixture.Build<UpdateCartItemCommand>().Create();

        // Act
        await _handler.Handle(updateCartItemCommand, CancellationToken.None);

        // Assert
        _serviceMock.Verify(
            x => x.UpdateCartItemAsync(updateCartItemCommand.ProductId, updateCartItemCommand.Quantity,
                CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenServiceThrowsException()
    {
        // Arrange
        var updateCartItemCommand = Fixture.Build<UpdateCartItemCommand>().Create();
        _serviceMock.Setup(x => x.UpdateCartItemAsync(updateCartItemCommand.ProductId, updateCartItemCommand.Quantity,
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("Unable to update item in cart"));

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _handler.Handle(updateCartItemCommand, CancellationToken.None));

        _serviceMock.Verify(
            x => x.UpdateCartItemAsync(updateCartItemCommand.ProductId, updateCartItemCommand.Quantity,
                CancellationToken.None), Times.Once);
    }
}