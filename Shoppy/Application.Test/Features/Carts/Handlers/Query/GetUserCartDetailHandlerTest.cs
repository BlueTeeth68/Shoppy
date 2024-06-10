using AutoFixture;
using Moq;
using Shoppy.Application.Features.Carts.Handlers.Query;
using Shoppy.Application.Features.Carts.Request.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Application.Test.Features.Carts.Handlers.Query;

public class GetUserCartDetailHandlerTest: TestBase
{
    private readonly Mock<IUserService> _serviceMock;
    private readonly GetUserCartDetailHandler _handler;

    public GetUserCartDetailHandlerTest()
    {
        _serviceMock = new Mock<IUserService>();
        _handler = new GetUserCartDetailHandler(_serviceMock.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnUserCartDetail_WhenQueryIsValid()
    {
        // Arrange
        var expectedCartDto = Fixture.Build<CartDto>().Create();

        _serviceMock.Setup(x => x.GetUserCartDetailAsync())
            .ReturnsAsync(expectedCartDto);

        var getUserCartDetailQuery = new GetUserCartDetailQuery();

        // Act
        var cartDto = await _handler.Handle(getUserCartDetailQuery, CancellationToken.None);

        // Assert
        Assert.Equal(expectedCartDto.TotalItem, cartDto.TotalItem);
        Assert.Equal(expectedCartDto.Items.Count, cartDto.Items.Count);

        _serviceMock.Verify(x => x.GetUserCartDetailAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenServiceThrowsException()
    {
        // Arrange
        var getUserCartDetailQuery = new GetUserCartDetailQuery();

        _serviceMock.Setup(x => x.GetUserCartDetailAsync())
            .ThrowsAsync(new InvalidOperationException("Unable to get user cart detail"));

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(getUserCartDetailQuery, CancellationToken.None));

        _serviceMock.Verify(x => x.GetUserCartDetailAsync(), Times.Once);
    }
}