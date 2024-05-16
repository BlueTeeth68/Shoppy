using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Shoppy.Application.Features.Orders.Requests.Command;

public class CreateOrderCommand: IRequest<Guid>
{
    [Required]
    public Guid UserId { get; set; }

    //Need to check validation
    public List<CreateOrderItemCommand> Items { get; set; } = [];
}