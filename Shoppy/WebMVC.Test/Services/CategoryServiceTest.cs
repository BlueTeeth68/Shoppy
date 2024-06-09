using System.Net;
using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Categories;
using Shoppy.WebMVC.Configurations;
using Shoppy.WebMVC.Services.Implements;

namespace WebMVC.Test.Services;

public class CategoryServiceTest : TestBase
{
    private readonly CategoryService _service;

    public CategoryServiceTest()
    {
        var appSettings = Fixture.Build<AppSettings>()
            .With(a => a.Apis, () => Fixture.Build<Api>()
                .With(a => a.BaseUrl, () => "https://localhost:44301/api/v1")
                .Create())
            .Create();
        _service = new CategoryService(HttpClient, appSettings);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResult()
    {
        // Arrange

        var mockResponseObject = Fixture.Build<BaseResult<List<CategoryDto>>>()
            .With(r => r.IsSuccess, () => true)
            .With(r => r.Error, () => null)
            .With(r => r.Result, () => Fixture.Build<List<CategoryDto>>().Create())
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
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
        Assert.NotNull(result.Result);
        Assert.Equal(mockResponseObject.Result?.Count, result.Result?.Count);
    }
}