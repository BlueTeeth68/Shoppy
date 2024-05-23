using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.Application.Mappers;

public static class OrderMapper
{

    public static OrderItem CartItemDtoToOrderItem(CartItemDto dto)
        => new ()
        {
            Price = dto.Price,
            Quantity = dto.Quantity,
            ProductId = dto.ProductId
        };

    public static Order CartDtoToOrder(CartDto dto)
    {
        var totalPrice = dto.Items.Sum(i => i.Price * i.Quantity);
        var items = dto.Items.Select(CartItemDtoToOrderItem).ToList();

        return new Order()
        {
            Items = items,
            TotalPrice = totalPrice,
            CreatedDateTime = DateTime.UtcNow,
            Status = OrderStatus.Success
        };
    }
}