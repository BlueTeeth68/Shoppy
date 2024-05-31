namespace Shoppy.SharedLibrary.Models.Responses.Products;

public class ProductRatingDto
{
    public Guid Id { get; set; }

    public int? RateValue { get; set; }

    public string? Comment { get; set; }

    public DateTime? Date { get; set; }

    public string UserName { get; set; } = null!;

    public string? PictureUrl { get; set; }
}