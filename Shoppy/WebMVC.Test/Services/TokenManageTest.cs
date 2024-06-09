using AutoFixture;
using Microsoft.AspNetCore.Http;
using Moq;
using Shoppy.SharedLibrary.Models.Responses.Auth;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Implements;

namespace WebMVC.Test.Services;

public class TokenManageTest : TestBase
{
    private readonly TokenManager _service;

    public TokenManageTest()
    {
        var appSettings = Fixture.Build<AppSettings>()
            .With(a => a.Apis, () => Fixture.Build<Api>()
                .With(a => a.BaseUrl, () => "https://localhost:44301/api/v1")
                .Create())
            .Create();
        _service = new TokenManager(HttpContextAccessorMock.Object, appSettings);
    }

    [Fact]
    public async Task AddCookieOptionsAsync_ShouldAppendCookiesToResponse()
    {
        // Arrange
        var cookieOptions = new CookieOptions
        {
            Expires = DateTimeOffset.Now.AddDays(1),
            HttpOnly = true,
            Secure = true
        };

        var cookieDict = new Dictionary<string, object>
        {
            { "token", "abcd1234" },
            { "userId", 1 }
        };

        var httpContextMock = new Mock<HttpContext>();
        var responseMock = new Mock<HttpResponse>();
        var cookieMock = new Mock<IResponseCookies>();
        httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);

        HttpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);
        responseMock.Setup(m => m.Cookies)
            .Returns(cookieMock.Object);

        // Act
        await _service.AddCookieOptionsAsync(cookieDict, cookieOptions);

        // Assert
        responseMock.Verify(r => r.Cookies.Append("token", "abcd1234", cookieOptions), Times.Once);
        responseMock.Verify(r => r.Cookies.Append("userId", "1", cookieOptions), Times.Once);
    }

    [Fact]
    public async Task AddLoginCookiesAsync_ShouldAppendCookiesToResponse()
    {
        // Arrange
        var requestMock = Fixture.Build<LoginResultDto>().Create();

        var httpContextMock = new Mock<HttpContext>();
        var responseMock = new Mock<HttpResponse>();
        var cookieMock = new Mock<IResponseCookies>();
        httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);

        HttpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);
        responseMock.Setup(m => m.Cookies)
            .Returns(cookieMock.Object);

        // Act
        await _service.AddLoginCookiesAsync(requestMock);

        // Assert
        responseMock.Verify(r => r.Cookies.Append("email", requestMock.Email ?? "", It.IsAny<CookieOptions>()),
            Times.Once);
        responseMock.Verify(
            r => r.Cookies.Append("accessToken", requestMock.AccessToken, It.IsAny<CookieOptions>()), Times.Once);
        responseMock.Verify(r => r.Cookies.Append("fullName", requestMock.FullName, It.IsAny<CookieOptions>()),
            Times.Once);
        responseMock.Verify(
            r => r.Cookies.Append("pictureUrl", requestMock.PictureUrl ?? "", It.IsAny<CookieOptions>()), Times.Once);
    }

    [Fact]
    public async Task AddRegisterCookiesAsync_ShouldAppendCookiesToResponse()
    {
        // Arrange
        var requestMock = Fixture.Build<RegisterResultDto>().Create();

        var httpContextMock = new Mock<HttpContext>();
        var responseMock = new Mock<HttpResponse>();
        var cookieMock = new Mock<IResponseCookies>();
        httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);

        HttpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);
        responseMock.Setup(m => m.Cookies)
            .Returns(cookieMock.Object);

        // Act
        await _service.AddRegisterCookiesAsync(requestMock);

        // Assert
        responseMock.Verify(r => r.Cookies.Append("email", requestMock.Email ?? "", It.IsAny<CookieOptions>()),
            Times.Once);
        responseMock.Verify(
            r => r.Cookies.Append("accessToken", requestMock.AccessToken, It.IsAny<CookieOptions>()), Times.Once);
        responseMock.Verify(r => r.Cookies.Append("fullName", requestMock.FullName, It.IsAny<CookieOptions>()),
            Times.Once);
        responseMock.Verify(
            r => r.Cookies.Append("refreshToken", requestMock.RefreshToken ?? "", It.IsAny<CookieOptions>()),
            Times.Once);
    }

    [Fact]
    public async Task GetAccessTokenAsync_ShouldReturnString()
    {
        // Arrange
        const string expectedData = "this is token";

        var httpContextMock = new Mock<HttpContext>();
        var httpRequestMock = new Mock<HttpRequest>();
        httpContextMock.SetupGet(x => x.Request).Returns(httpRequestMock.Object);

        HttpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);
        httpRequestMock.Setup(m => m.Cookies["accessToken"])
            .Returns(expectedData);

        // Act
        var result = await _service.GetAccessTokenAsync();

        // Assert

        Assert.NotNull(result);
        Assert.Equal(expectedData, result);
    }
}