using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Shoppy.Application.Features.Orders.Requests.Command;

public class CreateOrderCommand: IRequest<Guid>
{
    //Need to check validation
    public List<CreateOrderItemCommand> Items { get; set; } = [];
}