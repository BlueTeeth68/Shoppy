using MediatR;
using Shoppy.SharedLibrary.Models.Requests.Rating;

namespace Shoppy.Application.Features.ProductRatings.Request.Command;

public class CreateRatingCommand : AddRatingDto, IRequest
{
}