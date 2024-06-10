using AutoFixture;
using Moq;
using Shoppy.Application.Features.Categories.Handlers.Command;
using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;

namespace Application.Test.Features.Categories.Handlers.Command;

public class UpdateCommandHandlerTest: TestBase
{
    private readonly UpdateCommandHandler _handler;

    public UpdateCommandHandlerTest()
    {
        _handler = new UpdateCommandHandler(UnitOfWorkMock.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldUpdateProductCategory_WhenRequestIsValid()
    {
        // Arrange
        var request = Fixture.Build<UpdateCategoryCommand>().Create();

        var existingEntity = new ProductCategory
        {
            Id = request.Id,
            Name = "Existing Category",
            Description = "This is an existing category",
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow.AddDays(-1)
        };

        UnitOfWorkMock.Setup(x => x.ProductCategoryRepository.GetUpdateByIdAsync(request.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingEntity);

        UnitOfWorkMock.Setup(x => x.ProductCategoryRepository.UpdateAsync(It.IsAny<ProductCategory>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        UnitOfWorkMock.Setup(x => x.SaveChangeAsync())
            .ReturnsAsync(1);

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(request.Name, existingEntity.Name);
        Assert.Equal(request.Description, existingEntity.Description);
        Assert.True(existingEntity.UpdatedDateTime > existingEntity.CreatedDateTime);

        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.GetUpdateByIdAsync(request.Id, It.IsAny<CancellationToken>()), Times.Once);
        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.UpdateAsync(It.IsAny<ProductCategory>(), It.IsAny<CancellationToken>()), Times.Once);
        UnitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException_WhenCategoryNotFound()
    {
        // Arrange
        var request = Fixture.Build<UpdateCategoryCommand>().Create();

        UnitOfWorkMock.Setup(x => x.ProductCategoryRepository.GetUpdateByIdAsync(request.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((ProductCategory?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));

        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.GetUpdateByIdAsync(request.Id, It.IsAny<CancellationToken>()), Times.Once);
        UnitOfWorkMock.Verify(x => x.ProductCategoryRepository.UpdateAsync(It.IsAny<ProductCategory>(), It.IsAny<CancellationToken>()), Times.Never);
        UnitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Never);
    }
}