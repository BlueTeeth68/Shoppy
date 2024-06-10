using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using Shoppy.Application.Features.Products.Handlers.Command;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Products.Handlers.Command;

public class UpdateProductImageHandlerTest : TestBase
{
    private readonly Mock<IProductService> _serviceMock;
    private readonly UpdateProductImageHandler _handler;

    public UpdateProductImageHandlerTest()
    {
        _serviceMock = new Mock<IProductService>();
        _handler = new UpdateProductImageHandler(_serviceMock.Object);
    }

    [Theory]
    [InlineData("File name")]
    public async Task Handle_ShouldReturnCorrectString(string fileName)
    {
        //Arrange
        var bytes = "Product thumb"u8.ToArray();
        IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "image.png");
        var requestMock = Fixture.Build<UpdateProductImageCommand>()
            .With(r => r.File, () => file)
            .Create();

        _serviceMock.Setup(m => m.UpdateProductThumbAsync(requestMock, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fileName);
        //Act
        var result = await _handler.Handle(requestMock, default);

        //Assert
        Assert.Equal(fileName, result);
    }
}