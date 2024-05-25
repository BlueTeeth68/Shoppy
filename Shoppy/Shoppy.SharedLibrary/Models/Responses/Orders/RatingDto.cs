namespace Shoppy.SharedLibrary.Models.Responses.Orders;

public class RatingDto
{
    public Guid Id { get; set; }
    public int RateValue { get; set; }

    public string? Comment { get; set; }
}