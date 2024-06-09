using System.Net;
using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Auth;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Implements;

namespace WebMVC.Test.Services;

public class AuthServiceTest : TestBase
{
    private readonly AuthService _service;

    public AuthServiceTest()
    {
        var appSettings = Fixture.Build<AppSettings>()
            .With(a => a.Apis, () => Fixture.Build<Api>()
                .With(a => a.BaseUrl, () => "https://localhost:44301/api/v1")
                .Create())
            .Create();
        _service = new AuthService(HttpClient, appSettings);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnResult()
    {
        // Arrange
        var mockRequest = Fixture.Build<LoginDto>().Create();

        var mockResponseObject = Fixture.Build<BaseResult<LoginResponse>>()
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
        var result = await _service.LoginAsync(mockRequest);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.NotNull(result.Result);
        Assert.Equal(mockResponseObject.Result?.Id, result.Result?.Id);
        Assert.Equal(mockResponseObject.Result?.Email, result.Result?.Email);
    }
    
    [Fact]
    public async Task RegisterAsync_ShouldReturnResult()
    {
        // Arrange
        var mockRequest = Fixture.Build<RegisterDto>().Create();

        var mockResponseObject = Fixture.Build<BaseResult<RegisterResponse>>()
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
        var result = await _service.RegisterAsync(mockRequest);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.NotNull(result.Result);
        Assert.Equal(mockResponseObject.Result?.Id, result.Result?.Id);
        Assert.Equal(mockResponseObject.Result?.Email, result.Result?.Email);
    }
}