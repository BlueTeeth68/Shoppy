namespace Shoppy.SharedLibrary.Models.Responses.Carts;

public class CartItemDto
{
    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductThumbUrl { get; set; }
    public decimal Price { get; set; }
}