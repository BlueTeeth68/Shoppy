using AutoFixture;
using Moq;
using Shoppy.Application.Features.Categories.Handlers.Query;
using Shoppy.Application.Features.Categories.Requests.Query;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Entities;

namespace Application.Test.Features.Categories.Handlers.Query;

public class GetAllHandlerTest:TestBase
{
    private readonly GetAllHandler _handler;

    public GetAllHandlerTest()
    {
        _handler = new GetAllHandler(UnitOfWorkMock.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnAllCategories_WhenQueryIsValid()
    {
        // Arrange
        var existingEntities = Fixture.Build<ProductCategory>().CreateMany(5).ToList();

        var expectedResults = CategoryMapper.CategoryToCategoryResult(existingEntities);

        UnitOfWorkMock.Setup(x => x.ProductCategoryRepository.GetAllAsync(It.IsAny<CancellationToken>(), true))
            .ReturnsAsync(existingEntities);

        // Act
        var result = await _handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

        // Assert
        Assert.Equal(expectedResults.Count, result.Count);
        for (var i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i].Id, result[i].Id);
            Assert.Equal(expectedResults[i].Name, result[i].Name);
            Assert.Equal(expectedResults[i].Description, result[i].Description);
        }

        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.GetAllAsync(It.IsAny<CancellationToken>(), true), Times.Once);
    }
}