using Shoppy.Domain.Constants.Enums;

namespace Shoppy.SharedLibrary.Models.Responses.Orders;

public class OrderItemDto
{
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public string? ProductThumbUrl { get; set; }
    public string? ProductName { get; set; }
}