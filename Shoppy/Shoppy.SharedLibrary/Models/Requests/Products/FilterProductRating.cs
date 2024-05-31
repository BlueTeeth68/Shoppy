using System.ComponentModel.DataAnnotations;

namespace Shoppy.SharedLibrary.Models.Requests.Products;

public class FilterProductRating
{
    [Required] public Guid ProductId { get; set; }

    [Range(1, int.MaxValue)] public int? Page { get; set; }

    [Range(1, 50)] public int? Size { get; set; }
}