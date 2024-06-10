using AutoFixture;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Shoppy.Application.Features.Products.Handlers.Query;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories;

namespace Application.Test.Features.Products.Handlers.Query;

public class GetByIdQueryHandlerTest : TestBase
{
    private readonly GetByIdQueryHandler _handler;

    public GetByIdQueryHandlerTest()
    {
        _handler = new GetByIdQueryHandler(UnitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnCorrectData()
    {
        //Arrange
        var productList = Fixture.Build<Product>().CreateMany(5).ToList();
        var id = productList.Last().Id;
        var requestMock = Fixture.Build<GetProductByIdQuery>()
            .With(r => r.Id, () => id)
            .Create();
        var mockQueryable = productList.AsQueryable().BuildMock();

        var productRepositoryMock = new Mock<IProductRepository>();

        UnitOfWorkMock.Setup(m => m.ProductRepository)
            .Returns(productRepositoryMock.Object);
        productRepositoryMock.Setup(m => m.GetQueryableSet())
            .Returns(mockQueryable);

        //Act
        var result = await _handler.Handle(requestMock, default);

        //Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(id);
    }

    [Fact]
    public async Task Handle_ShouldThrowException()
    {
        //Arrange 
        var expectedId = new Guid("d940d52b-32d1-4ca4-870d-ebaa2ada4951");
        var productList = Fixture.Build<Product>()
            .With(r => r.Id, () => expectedId)
            .CreateMany(1).ToList();
        var requestMock = Fixture.Build<GetProductByIdQuery>()
            .With(r => r.Id, () => new Guid("78be8dbb-b3c5-4878-bda5-c10ff26b5555"))
            .Create();

        var mockQueryable = productList.AsQueryable().BuildMock();
        var productRepositoryMock = new Mock<IProductRepository>();
        UnitOfWorkMock.Setup(m => m.ProductRepository)
            .Returns(productRepositoryMock.Object);
        productRepositoryMock.Setup(m => m.GetQueryableSet())
            .Returns(mockQueryable);

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(requestMock, default));
    }
}