using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Persistence.Repositories.Base;

namespace Persistence.Test.Repositories;

public class BaseRepositoryTest : TestBase
{
    private readonly IBaseRepository<Product, Guid> _baseRepository;
    private readonly Mock<ILogger<Product>> _logger;


    public BaseRepositoryTest()
    {
        _logger = new Mock<ILogger<Product>>();
        _baseRepository = new BaseRepository<Product, Guid>(DbContext, _logger.Object);
    }

    #region Setup

    protected static readonly List<Product> Products =
    [
        new Product
        {
            Id = new Guid("c08bfb5d-b1d3-45a8-b0a8-654519242d93"), Name = "Product 1", RowVersion = [0x01, 0x02, 0x03]
        },
        new Product
        {
            Id = new Guid("a7ed8c84-8584-44fa-a086-90d2622be99b"), Name = "Product 2", RowVersion = [0x01, 0x02, 0x03]
        },
        new Product
        {
            Id = new Guid("757466b3-b654-473e-a80b-c486116f618b"), Name = "Product 3", RowVersion = [0x01, 0x02, 0x03]
        },
        new Product
        {
            Id = new Guid("0cee63da-bfbf-46f3-a863-ab4908abe54f"), Name = "Product 4", RowVersion = [0x01, 0x02, 0x03]
        },
        new Product
        {
            Id = new Guid("0a3faa9c-d4bc-494c-833b-46370bfcb918"), Name = "Product 5", RowVersion = [0x01, 0x02, 0x03]
        },
        new Product
        {
            Id = new Guid("7641a7d5-c6f1-45b7-a94c-7d3d0aa3ae12"), Name = "Product 6", RowVersion = [0x01, 0x02, 0x03]
        },
        new Product
        {
            Id = new Guid("9ff4a654-5108-4762-9292-25ba81e277bf"), Name = "Product 7", RowVersion = [0x01, 0x02, 0x03]
        },
        new Product
        {
            Id = new Guid("6ed7df0c-8d30-4f21-bf1e-939eb3a1c6e6"), Name = "Product 8", RowVersion = [0x01, 0x02, 0x03]
        },
    ];

    protected async Task InitDataAsync()
    {
        await DbContext.AddRangeAsync(Products);
        await DbContext.SaveChangesAsync();
    }

    #endregion

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
        await using (DbContext)
        {
            //Arrange
            await InitDataAsync();

            // Act
            var entities = await _baseRepository.GetAllAsync();

            // Assert
            Assert.Equal(Products.Count, entities.Count);
            Assert.All(entities, e => Assert.Contains(e, DbContext.Set<Product>()));
        }
    }

    #endregion

    #region GetByIdAsync Tests

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task GetByIdAsync_ShouldReturnEntity_WhenIdExist(int index)
    {
        //Arrange
        var product = Products[index];
        await using (DbContext)
        {
            await InitDataAsync();

            //Act
            var result = await _baseRepository.GetByIdAsync(product.Id);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<Product>(result);
            Assert.Equal(product.Id, result.Id);
        }
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEntity_WhenIdIsNotExist()
    {
        //Arrange
        var id = new Guid("325acfa6-80f3-4630-a69b-365831b0f806");
        await using (DbContext)
        {
            await InitDataAsync();

            //Act
            var result = await _baseRepository.GetByIdAsync(id);

            //Assert
            Assert.Null(result);
        }
    }

    #endregion

    #region AddAsync Tests

    [Fact]
    public async Task AddAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var data = new Product() { Id = new Guid(), Name = "Test", RowVersion = [0x01, 0x02, 0x03] };

        await using (DbContext)
        {
            //Act
            await _baseRepository.AddAsync(data);
            var result = await DbContext.SaveChangesAsync();

            //Assert
            result.Should().Be(1);
        }
    }

    #endregion

    #region AddRangeAsync Test

    [Fact]
    public async Task AddRangeAsync_ShouldReturnCorrectData()
    {
        await using (DbContext)
        {
            //Act
            await _baseRepository.AddRangeAsync(Products);
            var result = await DbContext.SaveChangesAsync();

            //Assert
            result.Should().Be(Products.Count);
        }
    }

    #endregion

    #region UpdateAsync Tests

    [Fact]
    public async Task UpdateAsync_ShouldReturnNumberOfEntityUpdated()
    {
        await using (DbContext)
        {
            //Arrange
            var data = new Product() { Id = new Guid(), Name = "Test", RowVersion = [0x01, 0x02, 0x03] };
            await DbContext.AddAsync(data);
            await DbContext.SaveChangesAsync();

            //Act
            await _baseRepository.UpdateAsync(data);
            var result = await DbContext.SaveChangesAsync();

            //Assert
            result.Should().Be(1);
        }
    }

    #endregion

    #region DeleteAsync Tests

    [Fact]
    public async Task DeleteAsync_ShouldReturnNumberOfDeletedRow()
    {
        await using (DbContext)
        {
            //Arrange
            var data = new Product() { Id = new Guid(), Name = "Test", RowVersion = [0x01, 0x02, 0x03] };
            await DbContext.AddAsync(data);
            await DbContext.SaveChangesAsync();

            //Act
            await _baseRepository.DeleteAsync(data);
            var result = await DbContext.SaveChangesAsync();

            //Assert
            result.Should().Be(1);
        }
    }

    #endregion

    #region UpdateRangeAsync Tests

    [Fact]
    public async Task UpdateRangeAsync_ShouldReturnNumberOfUpdatedRow()
    {
        await using (DbContext)
        {
            //Arrange
            await DbContext.AddRangeAsync(Products);
            await DbContext.SaveChangesAsync();

            //Act
            await _baseRepository.UpdateRangeAsync(Products);
            var result = await DbContext.SaveChangesAsync();

            //Assert
            result.Should().Be(Products.Count);
        }
    }

    #endregion

    #region ToPaginationAsync Tests

    [Theory]
    [InlineData(1, 2, 10)]
    [InlineData(2, 3, 10)]
    public async Task ToPaginationAsync_ShouldReturnCorrectData_WhenInputDataIsValid(int page, int size, int dataSize)
    {
        //Arrange
        var data = Fixture.Build<Product>()
            .CreateMany(dataSize);
        var mockData = data.AsQueryable().BuildMock();

        //Act
        await _baseRepository.ToPaginationAsync(ref mockData, page, size);
        var result = await mockData.ToListAsync();

        //Assert
        Assert.NotNull(data);
        Assert.Equal(size, result.Count);
        Assert.Equal(data.ToList()[(page - 1) * size].Id, result[0].Id);
    }

    #endregion

    // #region AddOrUpdateAsync Tests
    //
    // [Fact]
    // public async Task AddOrUpdateAsync_ShouldCallAddAsync_WhenIdIsNotNull()
    // {
    //     //Arrange
    //     var dataMock = new Product()
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Test"
    //     };
    //
    //     var baseRepoMock = new Mock<BaseRepository<Product, Guid>>();
    //     baseRepoMock.Setup(m => m.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
    //         .Returns(Task.CompletedTask);
    //     baseRepoMock.Setup(m => m.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
    //         .Returns(Task.CompletedTask);
    //
    //     //Act
    //     await baseRepoMock.Object.AddOrUpdateAsync(dataMock);
    //
    //     //Assert
    //     baseRepoMock.Verify(x => x.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Once);
    // }
    //
    // #endregion
}