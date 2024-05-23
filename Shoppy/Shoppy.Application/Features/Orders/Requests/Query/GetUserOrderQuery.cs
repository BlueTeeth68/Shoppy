using MediatR;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Requests.Orders;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.Application.Features.Orders.Requests.Query;

public class GetUserOrderQuery : GetUserOrderDto, IRequest<PagingResult<OrderQueryDto>>
{
}