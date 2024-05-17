namespace Shoppy.Application.Features.Orders.Results;

public class OrderItemQuery
{
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public string? ProductThumbUrl { get; set; }
    public string? ProductName { get; set; }
}