using Shoppy.Domain.Constants.Enums;

namespace Shoppy.Application.Features.Orders.Results;

public class OrderDetailQuery
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public ICollection<OrderItemQuery> Items { get; set; } = new List<OrderItemQuery>();
}