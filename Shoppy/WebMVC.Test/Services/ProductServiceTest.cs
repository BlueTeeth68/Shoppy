using System.Net;
using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.SharedLibrary.Models.Responses.Products;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Implements;

namespace WebMVC.Test.Services;

public class ProductServiceTest : TestBase
{
    private readonly ProductService _service;

    public ProductServiceTest()
    {
        var appSettings = Fixture.Build<AppSettings>()
            .With(a => a.Apis, () => Fixture.Build<Api>()
                .With(a => a.BaseUrl, () => "https://localhost:44301/api/v1")
                .Create())
            .Create();
        _service = new ProductService(HttpClient, appSettings);
    }

    [Fact]
    public async Task FilterProductAsync_ShouldReturnResult()
    {
        // Arrange
        var filterProductDto = Fixture.Build<FilterProductDto>().Create();

        var mockResponseObject = Fixture.Build<BaseResult<PagingResult<FilterProductResultDto>>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .Create();

        var mockResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonConvert.SerializeObject(mockResponseObject))
        };

        HttpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync((HttpRequestMessage _, CancellationToken _) => mockResponse);

        // Act
        var result = await _service.FilterProductAsync(filterProductDto);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Equal(mockResponseObject.Result?.Results.Count, result.Result?.Results.Count);
    }

    [Fact]
    public async Task FilterProductRatingAsync_ShouldReturnResult()
    {
        // Arrange
        var filterProductRating = Fixture.Build<FilterProductRating>().Create();

        var mockResponseObject = Fixture.Build<BaseResult<PagingResult<ProductRatingDto>>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .Create();

        var mockResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonConvert.SerializeObject(mockResponseObject))
        };

        HttpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync((HttpRequestMessage _, CancellationToken _) => mockResponse);

        // Act
        var result = await _service.FilterProductRatingAsync(filterProductRating);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Equal(mockResponseObject.Result?.Results.Count, result.Result?.Results.Count);
    }

    [Fact]
    public async Task GetByIdAync_ShouldReturnResult()
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<ProductDto>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .Create();

        var mockResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonConvert.SerializeObject(mockResponseObject))
        };

        HttpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync((HttpRequestMessage _, CancellationToken _) => mockResponse);

        // Act
        var result = await _service.GetByIdAsync(Guid.NewGuid());

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Equal(mockResponseObject.Result?.Id, result.Result?.Id);
    }
}