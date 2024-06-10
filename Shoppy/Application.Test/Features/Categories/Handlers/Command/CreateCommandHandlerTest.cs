using System.Linq.Expressions;
using AutoFixture;
using Moq;
using Shoppy.Application.Features.Categories.Handlers.Command;
using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;

namespace Application.Test.Features.Categories.Handlers.Command;

public class CreateCommandHandlerTest: TestBase
{
    private readonly CreateCommandHandler _handler;

    public CreateCommandHandlerTest()
    {
        _handler = new CreateCommandHandler(UnitOfWorkMock.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldCreateNewProductCategory_WhenRequestIsValid()
    {
        // Arrange
        var request = Fixture.Build<CreateCategoryCommand>().Create();

        UnitOfWorkMock.Setup(x => x.ProductCategoryRepository.ExistByExpressionAsync(It.IsAny<Expression<Func<ProductCategory, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        UnitOfWorkMock.Setup(x => x.ProductCategoryRepository.AddAsync(It.IsAny<ProductCategory>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        UnitOfWorkMock.Setup(x => x.SaveChangeAsync())
            .ReturnsAsync(1);

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.ExistByExpressionAsync(It.IsAny<Expression<Func<ProductCategory, bool>>>(), It.IsAny<CancellationToken>()), Times.Once);
        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.AddAsync(It.IsAny<ProductCategory>(), It.IsAny<CancellationToken>()), Times.Once);
        UnitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Once);
    }
    
    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenProductCategoryNameExists()
    {
        // Arrange
        var request = Fixture.Build<CreateCategoryCommand>().Create();

        UnitOfWorkMock.Setup(x => x.ProductCategoryRepository.ExistByExpressionAsync(It.IsAny<Expression<Func<ProductCategory, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _handler.Handle(request, CancellationToken.None));

        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.ExistByExpressionAsync(It.IsAny<Expression<Func<ProductCategory, bool>>>(), It.IsAny<CancellationToken>()), Times.Once);
        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.AddAsync(It.IsAny<ProductCategory>(), It.IsAny<CancellationToken>()), Times.Never);
        UnitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Never);
    }
}