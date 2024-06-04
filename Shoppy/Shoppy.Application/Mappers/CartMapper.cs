using Shoppy.Domain.Entities;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.Application.Mappers;

public class CartMapper
{
    public static CartItemDto CartItemToCartItemDto(CartItem entity)
        => new CartItemDto()
        {
            Quantity = entity.Quantity,
            ProductId = entity.ProductId,
            Price = entity.Product.Price,
            ProductThumbUrl = entity.Product.ProductThumbUrl,
            ProductName = entity.Product.Name
        };

    public static CartDto CartToCartDto(Cart entity)
        => new CartDto()
        {
            TotalItem = entity.TotalItem,
            Items = entity.Items.Select(CartItemToCartItemDto).ToList() 
        };
}