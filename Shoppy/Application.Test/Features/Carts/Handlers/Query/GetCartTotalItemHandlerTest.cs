using Moq;
using Shoppy.Application.Features.Carts.Handlers.Query;
using Shoppy.Application.Features.Carts.Request.Query;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Carts.Handlers.Query;

public class GetCartTotalItemHandlerTest
{
    private readonly Mock<IUserService> _serviceMock;
    private readonly GetCartTotalItemHandler _handler;

    public GetCartTotalItemHandlerTest()
    {
        _serviceMock = new Mock<IUserService>();
        _handler = new GetCartTotalItemHandler(_serviceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnCartTotalItemCount_WhenQueryIsValid()
    {
        // Arrange
        var expectedTotalItems = 5;
        _serviceMock.Setup(x => x.GetCartTotalItemAsync())
            .ReturnsAsync(expectedTotalItems);

        var getCartTotalItemQuery = new GetCartTotalItemQuery();

        // Act
        var totalItems = await _handler.Handle(getCartTotalItemQuery, CancellationToken.None);

        // Assert
        Assert.Equal(expectedTotalItems, totalItems);
        _serviceMock.Verify(x => x.GetCartTotalItemAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenServiceThrowsException()
    {
        // Arrange
        var getCartTotalItemQuery = new GetCartTotalItemQuery();

        _serviceMock.Setup(x => x.GetCartTotalItemAsync())
            .ThrowsAsync(new InvalidOperationException("Unable to get cart total items"));

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _handler.Handle(getCartTotalItemQuery, CancellationToken.None));

        _serviceMock.Verify(x => x.GetCartTotalItemAsync(), Times.Once);
    }
}