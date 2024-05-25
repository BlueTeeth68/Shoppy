using System.ComponentModel.DataAnnotations;

namespace Shoppy.SharedLibrary.Models.Requests.Rating;

public class AddRatingDto
{
    [Required] [Range(1, 5)] public int RateValue { get; set; }

    [StringLength(250)] public string? Comment { get; set; }
    
    [Required]
    public Guid OrderItemId { get; set; }
    
}