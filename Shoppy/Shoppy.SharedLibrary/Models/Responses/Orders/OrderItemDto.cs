namespace Shoppy.SharedLibrary.Models.Responses.Orders;

public class OrderItemDto
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool IsReview { get; set; }

    public Guid ProductId { get; set; }

    public string? ProductThumbUrl { get; set; }
    public string? ProductName { get; set; }
    
    public RatingDto? RatingDto { get; set; }
}