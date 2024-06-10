using Moq;
using Shoppy.Application.Features.ProductRatings.Handler.Command;
using Shoppy.Application.Features.ProductRatings.Request.Command;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Identity;

namespace Application.Test.Features.ProductRatings.Handlers;

public class CreateCommandHandlerTest : TestBase
{
    private readonly Mock<ICurrentUser> _currentUserMock;
    private readonly CreateCommandHandler _handler;

    public CreateCommandHandlerTest()
    {
        _currentUserMock = new Mock<ICurrentUser>();
        _handler = new CreateCommandHandler(UnitOfWorkMock.Object, _currentUserMock.Object);
    }

    [Fact]
    public async Task Handle_WhenOrderItemNotFound_ShouldThrowNotFoundException()
    {
        // Arrange
        var request = new CreateRatingCommand { OrderItemId = Guid.NewGuid() };
        UnitOfWorkMock
            .Setup(u => u.OrderItemRepository.GetByIdAsync(request.OrderItemId, It.IsAny<CancellationToken>(),
                It.IsAny<bool>()))
            .ReturnsAsync((OrderItem?)null);

        // Act and Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenUserIsNotAuthorized_ShouldThrowForbiddenException()
    {
        // Arrange
        var request = new CreateRatingCommand { OrderItemId = Guid.NewGuid() };
        var orderItem = new OrderItem { Order = new Order { UserId = Guid.NewGuid() } };
        _currentUserMock.Setup(c => c.UserId).Returns(Guid.NewGuid());
        UnitOfWorkMock
            .Setup(u => u.OrderItemRepository.GetByIdAsync(request.OrderItemId, It.IsAny<CancellationToken>(),
                It.IsAny<bool>()))
            .ReturnsAsync(orderItem);

        // Act and Assert
        await Assert.ThrowsAsync<ForbiddenException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenOrderItemAlreadyReviewed_ShouldThrowBadRequestException()
    {
        // Arrange
        var request = new CreateRatingCommand { OrderItemId = Guid.NewGuid() };
        var orderItem = new OrderItem { IsReviewed = true, Order = new Order { UserId = Guid.NewGuid() } };
        _currentUserMock.Setup(c => c.UserId).Returns(orderItem.Order.UserId);
        UnitOfWorkMock
            .Setup(u => u.OrderItemRepository.GetByIdAsync(request.OrderItemId, It.IsAny<CancellationToken>(),
                It.IsAny<bool>()))
            .ReturnsAsync(orderItem);

        // Act and Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenOrderItemIsValid_ShouldUpdateOrderItemAndProductAvgRate()
    {
        // Arrange
        var request = new CreateRatingCommand { OrderItemId = Guid.NewGuid(), RateValue = 4 };
        var orderItem = new OrderItem { IsReviewed = false, Order = new Order { UserId = Guid.NewGuid() } };
        var productOrderDetails = new List<OrderItem>()
            { new OrderItem { ProductRating = new ProductRating { RateValue = 3 } } };
        _currentUserMock.Setup(c => c.UserId).Returns(orderItem.Order.UserId);
        UnitOfWorkMock
            .Setup(u => u.OrderItemRepository.GetByIdAsync(request.OrderItemId, It.IsAny<CancellationToken>(),
                It.IsAny<bool>()))
            .ReturnsAsync(orderItem);
        UnitOfWorkMock.Setup(u => u.OrderItemRepository.GetProductOrderDetailAsync(orderItem.ProductId))
            .ReturnsAsync(productOrderDetails);
        UnitOfWorkMock.Setup(u => u.ProductRepository.UpdateAvgRateAsync(orderItem.ProductId, It.IsAny<decimal?>()))
            .Returns(Task.CompletedTask);

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(orderItem.IsReviewed);
        Assert.NotNull(orderItem.ProductRating);
        Assert.Equal(request.RateValue, orderItem.ProductRating.RateValue);
        UnitOfWorkMock.Verify(u => u.ProductRepository.UpdateAvgRateAsync(orderItem.ProductId, 3.5m), Times.Once);
    }
}