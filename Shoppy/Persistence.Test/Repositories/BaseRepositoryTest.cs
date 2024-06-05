using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Entities.Base;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Persistence.Repositories.Base;

namespace Persistence.Test.Repositories;

public class BaseRepositoryTest : TestBase
{
    private readonly IBaseRepository<Product, Guid> _baseRepository;

    public BaseRepositoryTest()
    {
        Mock<ILogger<Product>> logger = new();
        _baseRepository = new BaseRepository<Product, Guid>(DbContext, logger.Object);
    }

    #region SetRowVersion Tests

    [Fact]
    public void SetRowVersion_ShouldUpdatesOriginalValues()
    {
        // Arrange
        var entity = new Product { Id = Guid.NewGuid(), RowVersion = [0x01, 0x02, 0x03] };

        // Act
        _baseRepository.SetRowVersion(entity, [0x04, 0x05, 0x06]);

        // Assert
        Assert.Equal(new byte[] { 0x04, 0x05, 0x06 },
            DbContext.Entry(entity).OriginalValues[nameof(entity.RowVersion)]);
    }

    #endregion

    #region IsDbUpdateConcurrencyException Tests

    [Fact]
    public void IsDbUpdateConcurrencyException_ShouldReturnTrue_WhenExceptionIsDbUpdateConcurrencyException()
    {
        //Act
        var result = _baseRepository.IsDbUpdateConcurrencyException(new DbUpdateConcurrencyException());

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDbUpdateConcurrencyException_ShouldReturnFalse_WhenExceptionIsNotDbUpdateConcurrencyException()
    {
        //Act
        var result = _baseRepository.IsDbUpdateConcurrencyException(new Exception());

        //Assert
        Assert.False(result);
    }

    #endregion

    #region GetQueryableSet Tests

    [Fact]
    public void GetQueryableSet_ShouldReturnDbSet()
    {
        //Arrange

        //Act
        var result = _baseRepository.GetQueryableSet();

        //Assert
        Assert.IsAssignableFrom<IQueryable<Product>>(result);
        Assert.Equal(DbContext.Set<Product>(), result);
    }

    #endregion

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProduct()
    {
        var products = new List<Product>()
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1", RowVersion = [0x01, 0x02, 0x03] },
            new() { Id = Guid.NewGuid(), Name = "Product 2", RowVersion = [0x01, 0x02, 0x03] },
            new() { Id = Guid.NewGuid(), Name = "Product 3", RowVersion = [0x01, 0x02, 0x03] },
            new() { Id = Guid.NewGuid(), Name = "Product 4", RowVersion = [0x01, 0x02, 0x03] },
            new() { Id = Guid.NewGuid(), Name = "Product 5", RowVersion = [0x01, 0x02, 0x03] },
        };
        await DbContext.AddRangeAsync(products);
        await DbContext.SaveChangesAsync();

        // Act
        var entities = await _baseRepository.GetAllAsync();

        // Assert
        Assert.Equal(products.Count, entities.Count);
        Assert.All(entities, e => Assert.Contains(e, DbContext.Set<Product>()));
    }

    #endregion
}