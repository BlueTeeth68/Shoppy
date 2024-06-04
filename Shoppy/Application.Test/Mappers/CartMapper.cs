using Application.Test.FakeData;

namespace Application.Test.Mappers;

public class CartMapper
{
    [Fact]
    public void CartItemToCartItemDto_ValidEntity_ReturnCartItemDto()
    {
        //Arrange

        var product = DataGenerator.GetProductGenerator(Guid.NewGuid()).Generate();
        var entity = DataGenerator.GetCartItemGenerator(product, Guid.NewGuid()).Generate();

        //Act
        var result = Shoppy.Application.Mappers.CartMapper.CartItemToCartItemDto(entity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(entity.ProductId, result.ProductId);
        Assert.Equal(entity.Quantity, result.Quantity);
        Assert.Equal(entity.Product.Price, result.Price);
        Assert.Equal(entity.Product.ProductThumbUrl, result.ProductThumbUrl);
        Assert.Equal(entity.Product.Name, result.ProductName);
    }
    
}