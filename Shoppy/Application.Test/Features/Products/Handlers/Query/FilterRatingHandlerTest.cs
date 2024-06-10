using AutoFixture;
using FluentAssertions;
using Moq;
using Shoppy.Application.Features.Products.Handlers.Query;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Responses.Products;

namespace Application.Test.Features.Products.Handlers.Query;

public class FilterRatingHandlerTest : TestBase
{
    private readonly Mock<IProductService> _service;
    private readonly FilterRatingHandler _handler;

    public FilterRatingHandlerTest()
    {
        _service = new Mock<IProductService>();
        _handler = new FilterRatingHandler(_service.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnCorrectData()
    {
        //Arrange
        var requestMock = Fixture.Build<FilterProductRatingQuery>().Create();
        var expectedData = Fixture.Build<PagingResult<ProductRatingDto>>().Create();

        _service.Setup(m => m.FilterProductRatingAsync(requestMock))
            .ReturnsAsync(expectedData);

        //Act
        var result = await _handler.Handle(requestMock, default);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedData);
    }
}