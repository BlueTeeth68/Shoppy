using System.ComponentModel.DataAnnotations;

namespace Shoppy.SharedLibrary.Models.Requests.Carts;

public class UpdateCartItemDto
{
    [Required] public Guid ProductId { get; set; }

    [Required] [Range(1, 10000)] public int Quantity { get; set; }
}