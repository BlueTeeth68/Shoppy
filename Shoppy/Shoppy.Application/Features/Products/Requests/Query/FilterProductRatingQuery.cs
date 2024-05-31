using MediatR;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.SharedLibrary.Models.Responses.Products;

namespace Shoppy.Application.Features.Products.Requests.Query;

public class FilterProductRatingQuery: FilterProductRating, IRequest<PagingResult<ProductRatingDto>>
{
    
}