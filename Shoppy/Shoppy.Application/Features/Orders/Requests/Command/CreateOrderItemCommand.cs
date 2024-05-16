using System.ComponentModel.DataAnnotations;

namespace Shoppy.Application.Features.Orders.Requests.Command;

public class CreateOrderItemCommand
{
    [Required]
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, 1000)]
    public int Quantity { get; set; }

    [Required]
    public Guid ProductId { get; set; }
}