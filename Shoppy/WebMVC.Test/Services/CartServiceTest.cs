using System.Net;
using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Carts;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.ExceptionHandlers;
using Shoppy.WebMVC.Services.Implements;

namespace WebMVC.Test.Services;

public class CartServiceTest : TestBase
{
    private readonly CartService _service;

    public CartServiceTest()
    {
        var appSettings = Fixture.Build<AppSettings>()
            .With(a => a.Apis, () => Fixture.Build<Api>()
                .With(a => a.BaseUrl, () => "https://localhost:44301/api/v1")
                .Create())
            .Create();
        _service = new CartService(appSettings, HttpClient);
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task AddReviewAsync_ShouldReturnResult(string token)
    {
        // Arrange

        var mockResponseObject = Fixture.Build<BaseResult<CartDto>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => Fixture.Build<CartDto>().Create())
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
        var result = await _service.GetCartAsync(token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.NotNull(result.Result);
        Assert.Equal(mockResponseObject.Result?.TotalItem, result.Result?.TotalItem);
        Assert.Equal(mockResponseObject.Result?.Items.Count, result.Result?.Items.Count);
    }

    [Fact]
    public async Task AddReviewAsync_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<CartDto>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => Fixture.Build<CartDto>().Create())
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
            _service.GetCartAsync(null));
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task GetCartTotalItemAsync_ShouldReturnResult(string token)
    {
        // Arrange

        var mockResponseObject = Fixture.Build<BaseResult<int>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => 10)
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
        var result = await _service.GetCartTotalItemAsync(token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Equal(mockResponseObject.Result, result.Result);
    }

    [Fact]
    public async Task GetCartTotalItemAsync_ShouldThrowUnauthorizedException()
    {
        // Arrange
        var mockResponseObject = Fixture.Build<BaseResult<int>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => 10)
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
            _service.GetCartTotalItemAsync(null));
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task AddToCartAsync_ShouldReturnResult(string token)
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
        var result = await _service.AddToCartAsync(Guid.NewGuid(), token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task AddToCartAsync_ShouldThrowUnauthorizedException()
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
        await Assert.ThrowsAsync<UnauthenticatedException>(() =>
            _service.AddToCartAsync(Guid.NewGuid(), null));
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task RemoveFromCartAsync_ShouldReturnResult(string token)
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
        var result = await _service.RemoveFromCartAsync(Guid.NewGuid(), token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task RemoveFromCartAsync_ShouldThrowUnauthorizedException()
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
        await Assert.ThrowsAsync<UnauthenticatedException>(() =>
            _service.RemoveFromCartAsync(Guid.NewGuid(), null));
    }

    [Theory]
    [InlineData("token 1")]
    [InlineData(
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzI1NzYwMS1lMzViLTQ0MDItMmYwOS0wOGRjN2FkNjExMjMiLCJqdGkiOiJjMDgyYmQ4Zi1lMDJkLTQ2NDItYTEyMS1jNTE1ZGMwZGU5ZmIiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNzE3OTExMTY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI0LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMjQvIn0.far4F1Gx8bs43UDgBTMXZaQf8y7YT5csvrswtFZnq3c")]
    public async Task UpdateCartItemAsync_ShouldReturnResult(string token)
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
        var result = await _service.UpdateCartItemAsync(Guid.NewGuid(), 10, token);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.Null(result.Result);
    }

    [Fact]
    public async Task UpdateCartItemAsync_ShouldThrowUnauthorizedException()
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
        await Assert.ThrowsAsync<UnauthenticatedException>(() =>
            _service.UpdateCartItemAsync(Guid.NewGuid(), 10, null));
    }
}