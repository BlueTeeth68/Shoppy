using AutoFixture;
using Moq;
using Shoppy.Application.Features.Categories.Handlers.Query;
using Shoppy.Application.Features.Categories.Requests.Query;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;

namespace Application.Test.Features.Categories.Handlers.Query;

public class GetByIdQueryHandlerTest : TestBase
{
    private readonly GetByIdQueryHandler _handler;

    public GetByIdQueryHandlerTest()
    {
        _handler = new GetByIdQueryHandler(UnitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnCategory_WhenIdExists()
    {
        // Arrange
        var existingCategory = Fixture.Build<ProductCategory>().Create();

        var expectedResult = CategoryMapper.CategoryToCategoryResult(existingCategory);

        UnitOfWorkMock.Setup(x =>
                x.ProductCategoryRepository.GetByIdAsync(existingCategory.Id, It.IsAny<CancellationToken>(),
                    It.IsAny<bool>()))
            .ReturnsAsync(existingCategory);

        // Act
        var result = await _handler.Handle(new GetCategoryByIdQuery(existingCategory.Id), CancellationToken.None);

        // Assert
        Assert.Equal(expectedResult.Id, result.Id);
        Assert.Equal(expectedResult.Name, result.Name);
        Assert.Equal(expectedResult.Description, result.Description);

        UnitOfWorkMock.Verify(
            x => x.ProductCategoryRepository.GetByIdAsync(existingCategory.Id, It.IsAny<CancellationToken>(),
                It.IsAny<bool>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException_WhenIdDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        UnitOfWorkMock
            .Setup(x => x.ProductCategoryRepository.GetByIdAsync(nonExistentId, It.IsAny<CancellationToken>(),
                It.IsAny<bool>()))
            .ReturnsAsync((ProductCategory?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() =>
            _handler.Handle(new GetCategoryByIdQuery(nonExistentId), CancellationToken.None));

        UnitOfWorkMock.Verify(
            x => x.ProductCategoryRepository.GetByIdAsync(nonExistentId, It.IsAny<CancellationToken>(),
                It.IsAny<bool>()), Times.Once);
    }
}