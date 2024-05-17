using System.ComponentModel.DataAnnotations;

namespace Shoppy.Application.Features.ProductRatings.Request.Command;

public record CreateRatingCommand
{
    [Required] [Range(0.5, 5)] public int RateValue { get; set; }

    [StringLength(250)] public string? Comment { get; set; }

    public Guid ProductId { get; set; }
}