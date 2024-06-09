using System.Net;
using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Rating;
using Shoppy.SharedLibrary.Models.Responses.Orders;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.ExceptionHandlers;
using Shoppy.WebMVC.Services.Implements;

namespace WebMVC.Test.Services;

public class OrderServiceTest : TestBase
{
    private readonly OrderService _service;

    public OrderServiceTest()
    {
        var appSettings = Fixture.Build<AppSettings>()
            .With(a => a.Apis, () => Fixture.Build<Api>()
                .With(a => a.BaseUrl, () => "https://localhost:44301/api/v1")
                .Create())
            .Create();
        _service = new OrderService(HttpClient, appSettings);
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task CreateOrderAsync_ShouldReturnResult(string token)
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<object>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => null)
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
        var result = await _service.CreateOrderAsync(token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task CreateOrderAsync_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<object>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => null)
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
        // Assert
        await Assert.ThrowsAsync<UnauthenticatedException>(() => _service.CreateOrderAsync(null));
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task FilterUserOrderAsync_ShouldReturnResult(string token)
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<PagingResult<OrderQueryDto>>>()
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
        var result = await _service.FilterUserOrderAsync(1, 10, token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Equal(mockResponseObject.Result?.Results.Count, result.Result?.Results.Count);
    }

    [Fact]
    public async Task FilterUserOrderAsync_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<PagingResult<OrderQueryDto>>>()
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
        // Assert
        await Assert.ThrowsAsync<UnauthenticatedException>(() => _service.FilterUserOrderAsync(1, 10, null));
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task GetOrderByIdAsync_ShouldReturnResult(string token)
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<OrderDto>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => Fixture.Build<OrderDto>()
                .With(o => o.Id, Guid.NewGuid)
                .Create())
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
        var result = await _service.GetOrderByIdAsync(mockResponseObject.Result?.Id ?? Guid.NewGuid(), token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Equal(mockResponseObject.Result?.Id, result.Result?.Id);
    }

    [Fact]
    public async Task GetOrderByIdAsync_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<OrderDto>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => Fixture.Build<OrderDto>()
                .With(o => o.Id, Guid.NewGuid)
                .Create())
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
        // Assert
        await Assert.ThrowsAsync<UnauthenticatedException>(() =>
            _service.GetOrderByIdAsync(mockResponseObject.Result?.Id ?? Guid.NewGuid(), null));
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task AddReviewAsync_ShouldReturnResult(string token)
    {
        // Arrange
        var mockRequest = Fixture.Build<AddRatingDto>().Create();

        var mockResponseObject = Fixture.Build<BaseResult<object>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => null)
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
        var result = await _service.AddReviewAsync(mockRequest, token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task AddReviewAsync_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var mockRequest = Fixture.Build<AddRatingDto>().Create();

        var mockResponseObject = Fixture.Build<BaseResult<object>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => null)
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
        // Assert
        await Assert.ThrowsAsync<UnauthenticatedException>(() =>
            _service.AddReviewAsync(mockRequest, null));
    }
}