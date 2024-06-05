using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.Infrastructure.Services;
using Shoppy.Persistence.Identity;

namespace Infrastructure.Test.Services;

public class ProductServiceTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IProductRepository> _productRepository;
    private readonly Mock<IFileService> _fileService;
    private readonly Mock<UserManager<AppUser>> _userManager;
    private readonly IProductService _productService;
    private readonly ILogger<ProductService> _logger;

    public ProductServiceTest()
    {
        _logger = new Mock<ILogger<ProductService>>().Object;
        _unitOfWork = new Mock<IUnitOfWork>();
        _productRepository = new Mock<IProductRepository>();
        _fileService = new Mock<IFileService>();
        _userManager = new Mock<UserManager<AppUser>>(Mock.Of<IUserStore<AppUser>>(), null!, null!, null!, null!, null!,
            null!, null!, null!);
        _productService = new ProductService(_unitOfWork.Object, _logger, _fileService.Object, _userManager.Object);
    }


    #region setup data

    private static readonly List<ProductCategory> CategoryIds =
    [
        new ProductCategory()
        {
            Id = new Guid("c1a0c3a1-264a-4d00-9521-128b8c6d0b90"),
            Name = "Test 1"
        },

        new ProductCategory()
        {
            Id = new Guid("a07ef92b-cba1-420a-8bc8-ce8f358e302f"),
            Name = "Test 2"
        }
    ];

    private static readonly List<Product> Products =
    [
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Test 1",
            Price = 10,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[1].Id
        },

        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Test 2",
            Price = 9,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[0].Id
        },

        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Test 3",
            Price = 11,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[1].Id
        },

        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Test 4",
            Price = 16,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[1].Id
        },

        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Price = 16,
            Status = ProductStatus.Inactive,
            CategoryId = CategoryIds[1].Id
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Test 6",
            Price = 5,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[0].Id
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 7",
            Price = 5,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[0].Id
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 8",
            Price = 6,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[0].Id
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 9",
            Price = 6,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[0].Id
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 10",
            Price = 6,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[0].Id
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 11",
            Price = 6,
            Status = ProductStatus.Active,
            CategoryId = CategoryIds[0].Id
        }
    ];

    #endregion

    [Fact]
    public async Task FilterProductAsync_Should_ReturnPagingResult_WhenFilterValid()
    {
        //Arrange
        var filter = new FilterProductQuery()
        {
            Name = "Test",
            Status = ProductStatus.Active,
            SortName = "asc",
            SortPrice = "asc",
            CategoryId = CategoryIds[1].Id,
            Page = 1,
            Size = 6
        };

        var mock = Products.AsQueryable().BuildMock();

        _unitOfWork.Setup(u => u.ProductRepository)
            .Returns(_productRepository.Object);
        _productRepository.Setup(p => p.GetQueryableSet())
            .Returns(mock);

        //Act
        var result = await _productService.FilterProductAsync(filter);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.TotalRecords);
    }
    
    [Theory]
    [InlineData(1, null)]
    [InlineData(0, 6)]
    [InlineData(-1, 4)]
    [InlineData(1, 0)]
    [InlineData(1, -1)]
    [InlineData(null, 4)]
    public async Task FilterProductAsync_Should_ReturnDefaultPageSize_WhenPageSizeIsInvalid(int? page, int? size)
    {
        //Arrange
        var filter = new FilterProductQuery()
        {
            Page = page,
            Size = size
        };

        var mock = Products.AsQueryable().BuildMock();

        _unitOfWork.Setup(u => u.ProductRepository)
            .Returns(_productRepository.Object);
        _productRepository.Setup(p => p.GetQueryableSet())
            .Returns(mock);

        //Act
        var result = await _productService.FilterProductAsync(filter);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(Products.Count, result.TotalRecords);
        Assert.Equal(10, result.Results.Count);
    }
}