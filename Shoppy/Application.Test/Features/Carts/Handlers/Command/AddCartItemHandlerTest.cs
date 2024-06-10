using AutoFixture;
using Moq;
using Shoppy.Application.Features.Carts.Handlers.Command;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Carts.Handlers.Command;

public class AddCartItemHandlerTest : TestBase
{
    private readonly Mock<IUserService> _serviceMock;
    private readonly AddCartItemHandler _handler;

    public AddCartItemHandlerTest()
    {
        _serviceMock = new Mock<IUserService>();
        _handler = new AddCartItemHandler(_serviceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallAddToCartAsync_WhenRequestIsValid()
    {
        // Arrange
        var addCartItemCommand = Fixture.Build<AddCartItemCommand>().Create();

        // Act
        await _handler.Handle(addCartItemCommand, CancellationToken.None);

        // Assert
        _serviceMock.Verify(x => x.AddToCartAsync(addCartItemCommand, CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenServiceThrowsException()
    {
        // Arrange
        var addCartItemCommand = Fixture.Build<AddCartItemCommand>().Create();

        _serviceMock.Setup(x => x.AddToCartAsync(addCartItemCommand, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("Unable to add item to cart"));

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _handler.Handle(addCartItemCommand, CancellationToken.None));

        _serviceMock.Verify(x => x.AddToCartAsync(addCartItemCommand, CancellationToken.None), Times.Once);
    }
}