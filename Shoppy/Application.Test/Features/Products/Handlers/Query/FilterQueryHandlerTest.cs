using AutoFixture;
using FluentAssertions;
using Moq;
using Shoppy.Application.Features.Products.Handlers.Query;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;

namespace Application.Test.Features.Products.Handlers.Query;

public class FilterQueryHandlerTest: TestBase
{
    private readonly Mock<IProductService> _service;
    private readonly FilterQueryHandler _handler;

    public FilterQueryHandlerTest()
    {
        _service = new Mock<IProductService>();
        _handler = new FilterQueryHandler(_service.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnCorrectData()
    {
        //Arrange
        var requestMock = Fixture.Build<FilterProductQuery>().Create();
        var expectedData = Fixture.Build<PagingResult<FilterProductResult>>().Create();

        _service.Setup(m => m.FilterProductAsync(requestMock))
            .ReturnsAsync(expectedData);

        //Act
        var result = await _handler.Handle(requestMock, default);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedData);
    }
}