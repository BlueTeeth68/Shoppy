using Microsoft.AspNetCore.Http;
using Moq;
using CoreTestBase = Core.Test.CoreTestBase;

namespace WebMVC.Test;

public class TestBase : CoreTestBase
{
    protected readonly Mock<IHttpContextAccessor> HttpContextAccessorMock;
    protected readonly HttpClient HttpClient;
    protected readonly Mock<HttpMessageHandler> HttpMessageHandlerMock;

    public TestBase()
    {
        HttpMessageHandlerMock = new Mock<HttpMessageHandler>();
        
        HttpClient = new HttpClient(HttpMessageHandlerMock.Object);
        HttpContextAccessorMock = new Mock<IHttpContextAccessor>();
    }
}