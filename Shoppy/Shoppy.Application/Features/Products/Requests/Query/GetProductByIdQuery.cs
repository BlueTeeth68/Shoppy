using MediatR;
using Shoppy.Application.Features.Products.Results.Query;

namespace Shoppy.Application.Features.Products.Requests.Query;

public record GetProductByIdQuery(
    Guid Id
) : IRequest<ProductDetailQueryResult>;