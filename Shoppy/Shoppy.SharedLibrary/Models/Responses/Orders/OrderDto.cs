using Shoppy.Domain.Constants.Enums;

namespace Shoppy.SharedLibrary.Models.Responses.Orders;

public class OrderDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }
    
    public DateTime Date { get; set; }

    public ICollection<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
}