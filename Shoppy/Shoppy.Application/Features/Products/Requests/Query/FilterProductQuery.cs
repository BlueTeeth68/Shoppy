using MediatR;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Requests.Products;

namespace Shoppy.Application.Features.Products.Requests.Query;

public class FilterProductQuery : FilterProductDto, IRequest<PagingResult<FilterProductResult>>
{
}