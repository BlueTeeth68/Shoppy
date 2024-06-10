using AutoFixture;
using Moq;
using Shoppy.Application.Features.Products.Handlers.Command;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Products.Handlers.Command;

public class UpdateCommandHandlerTest : TestBase
{
    private readonly UpdateCommandHandler _handler;
    private readonly Mock<IProductService> _service;

    public UpdateCommandHandlerTest()
    {
        _service = new Mock<IProductService>();
        _handler = new UpdateCommandHandler(_service.Object);
    }

    [Fact]
    public async Task Handler_ShouldCallCorrectMethod()
    {
        //Arrange
        var requestMock = Fixture.Build<UpdateProductCommand>()
            .With(r => r.ProductThumb, () => null)
            .Create();
        _service.Setup(m => m.UpdateAsync(requestMock, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act
        await _handler.Handle(requestMock, default);

        //Assert
        _service.Verify(p => p.UpdateAsync(requestMock, default), Times.Once);
    }
}