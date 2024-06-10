using AutoFixture;
using Moq;
using Shoppy.Application.Features.Products.Handlers.Command;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories;

namespace Application.Test.Features.Products.Handlers.Command;

public class DeleteCommandHandlerTest : TestBase
{
    private readonly DeleteCommandHandler _handler;

    public DeleteCommandHandlerTest()
    {
        _handler = new DeleteCommandHandler(UnitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCallCorrectMethod()
    {
        //Arrange
        var entityMock = Fixture.Build<Product>().Create();
        var requestMock = Fixture.Build<DeleteProductCommand>().Create();

        var productRepositoryMock = new Mock<IProductRepository>();

        UnitOfWorkMock.Setup(m => m.ProductRepository)
            .Returns(productRepositoryMock.Object);
        UnitOfWorkMock.Setup(m => m.SaveChangeAsync())
            .ReturnsAsync(1);

        productRepositoryMock
            .Setup(m => m.GetByIdAsync(requestMock.Id, It.IsAny<CancellationToken>(), It.IsAny<bool>()))
            .ReturnsAsync(entityMock);

        //Act
        await _handler.Handle(requestMock, default);

        //Assert
        productRepositoryMock.Verify(
            p => p.GetByIdAsync(requestMock.Id, It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);
        UnitOfWorkMock.Verify(
            u => u.SaveChangeAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException()
    {
        //Arrange
        var requestMock = Fixture.Build<DeleteProductCommand>().Create();

        var productRepositoryMock = new Mock<IProductRepository>();

        UnitOfWorkMock.Setup(m => m.ProductRepository)
            .Returns(productRepositoryMock.Object);
        UnitOfWorkMock.Setup(m => m.SaveChangeAsync())
            .ReturnsAsync(1);

        productRepositoryMock
            .Setup(m => m.GetByIdAsync(requestMock.Id, It.IsAny<CancellationToken>(), It.IsAny<bool>()))
            .ReturnsAsync((Product?)null);

        //Act
        //Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _handler.Handle(requestMock, default));
    }
}