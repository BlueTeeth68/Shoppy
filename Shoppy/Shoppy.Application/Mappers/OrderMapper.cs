using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Domain.Entities;

namespace Shoppy.Application.Mappers;

public static class OrderMapper
{
    public static OrderItem CreateOrderItemToOrderItem(CreateOrderItemCommand dto)
        => new OrderItem()
        {
            Price = dto.Price,
            Quantity = dto.Quantity,
            ProductId = dto.ProductId
        };

    public static Order CreateOrderToOrder(CreateOrderCommand dto)
    {
        var totalPrice = dto.Items.Sum(item => item.Price * item.Quantity);
        var items = dto.Items.Select(CreateOrderItemToOrderItem).ToList();

        return new Order()
        {
            UserId = dto.UserId,
            Items = items,
            TotalPrice = totalPrice
        };
    }
}