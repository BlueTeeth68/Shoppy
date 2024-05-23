namespace Shoppy.SharedLibrary.Models.Responses.Carts;

public class CartDto
{
    public int TotalItem { get; set; }

    public List<CartItemDto> Items { get; set; } = [];
}