using AutoFixture;
using FluentAssertions;
using Moq;
using Shoppy.Application.Features.Orders.Handlers.Query;
using Shoppy.Application.Features.Orders.Requests.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Application.Test.Features.Orders.Handlers.Query;

public class GetUserOrderHandlerTest : TestBase
{
    private readonly Mock<IOrderService> _serviceMock;
    private readonly GetUserOrderHandler _handler;

    public GetUserOrderHandlerTest()
    {
        _serviceMock = new Mock<IOrderService>();
        _handler = new GetUserOrderHandler(_serviceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnPagingResult_WhenQueryParamsAreProvided()
    {
        // Arrange
        var request = new GetUserOrderQuery
        {
            Page = 2,
            Size = 20
        };

        var mockOrders = Fixture.Build<OrderQueryDto>().CreateMany(3).ToList();

        var mockPagingResult = Fixture.Build<PagingResult<OrderQueryDto>>()
            .With(r => r.Results, () => mockOrders)
            .Create();

        _serviceMock.Setup(s =>
                s.FilterUserOrderAsync(request.Page.Value, request.Size.Value, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockPagingResult);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Results.Should().BeEquivalentTo(mockOrders);
        result.TotalPages.Should().Be(mockPagingResult.TotalPages);
        result.TotalRecords.Should().Be(mockPagingResult.TotalRecords);
    }

    [Fact]
    public async Task Handle_ShouldSetDefaultPageAndSize_WhenQueryParamsAreNotProvided()
    {
        // Arrange
        var request = new GetUserOrderQuery();

        var mockOrders = Fixture.Build<OrderQueryDto>().CreateMany(3).ToList();

        var mockPagingResult = Fixture.Build<PagingResult<OrderQueryDto>>()
            .With(r => r.Results, () => mockOrders)
            .Create();


        _serviceMock.Setup(s => s.FilterUserOrderAsync(1, 10, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockPagingResult);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Results.Should().BeEquivalentTo(mockOrders);
        result.TotalPages.Should().Be(mockPagingResult.TotalPages);
        result.TotalRecords.Should().Be(mockPagingResult.TotalRecords);
    }
}