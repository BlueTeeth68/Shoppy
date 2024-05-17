using System.ComponentModel.DataAnnotations;
using MediatR;
using Shoppy.Application.Features.Orders.Results;

namespace Shoppy.Application.Features.Orders.Requests.Query;

public class GetOrderDetailQuery: IRequest<OrderDetailQuery>
{
    [Required] public Guid Id { get; set; }
}