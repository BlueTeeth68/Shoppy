using Moq;
using Shoppy.Application.Features.Products.Handlers.Command;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.Products.Handlers.Command;

public class CreateCommandHandlerTest
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly CreateCommandHandler _handler;

    public CreateCommandHandlerTest()
    {
        _productServiceMock = new Mock<IProductService>();
        _handler = new CreateCommandHandler(_productServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnAnId()
    {
        //Arrange
        var id = Guid.NewGuid();
        _productServiceMock.Setup(p => p.CreateAsync(It.IsAny<CreateProductCommand>(), default))
            .Returns(Task.FromResult(id));
        var createProductCommand = new CreateProductCommand();

        //Act
        var result = await _handler.Handle(createProductCommand, default);

        //Assert
        Assert.Equal(id, result);
    } 
}