using Shoppy.Application.Features.ProductRatings.Request.Command;
using Shoppy.Domain.Entities;

namespace Shoppy.Application.Mappers;

public static class RatingMapper
{
    public static ProductRating RatingDtoToEntity(CreateRatingCommand dto)
        => new ProductRating()
        {
            RateValue = dto.RateValue,
            Comment = dto.Comment,
            OrderItemId = dto.OrderItemId,
            CreatedDateTime = DateTime.UtcNow
        };
}