using AutoFixture;
using FluentAssertions;
using Shoppy.Application.Features.Orders.Handlers.Query;
using Shoppy.Application.Features.Orders.Requests.Query;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;

namespace Application.Test.Features.Orders.Handlers.Query;

public class GetDetailQueryHandlerTest : TestBase
{
    private readonly GetDetailQueryHandler _handler;

    public GetDetailQueryHandlerTest()
    {
        _handler = new GetDetailQueryHandler(UnitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnOrderDto_WhenOrderExists()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var getOrderDetailQuery = new GetOrderDetailQuery { Id = orderId };

        var mockOrder = Fixture.Build<Order>()
            .With(o => o.Id, () => orderId)
            .Create();

        UnitOfWorkMock.Setup(u => u.OrderRepository.GetQueryableSet())
            .Returns(new[] { mockOrder }.AsQueryable());

        // Act
        var result = await _handler.Handle(getOrderDetailQuery, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(orderId);
        result.TotalPrice.Should().Be(mockOrder.TotalPrice);
        result.UserId.Should().NotBeEmpty();
        result.Items.Should().HaveCount(mockOrder.Items.Count);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException_WhenOrderNotFound()
    {
        // Arrange
        var getOrderDetailQuery = new GetOrderDetailQuery { Id = Guid.NewGuid() };

        UnitOfWorkMock.Setup(u => u.OrderRepository.GetQueryableSet())
            .Returns(Array.Empty<Order>().AsQueryable());

        // Act
        Func<Task> act = async () => await _handler.Handle(getOrderDetailQuery, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Order {getOrderDetailQuery.Id} not found.");
    }
}