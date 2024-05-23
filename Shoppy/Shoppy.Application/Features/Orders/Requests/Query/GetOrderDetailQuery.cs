using System.ComponentModel.DataAnnotations;
using MediatR;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.Application.Features.Orders.Requests.Query;

public class GetOrderDetailQuery: IRequest<OrderDto>
{
    [Required] public Guid Id { get; set; }
}