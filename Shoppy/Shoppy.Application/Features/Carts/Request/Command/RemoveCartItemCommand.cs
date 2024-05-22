using MediatR;

namespace Shoppy.Application.Features.Carts.Request.Command;

public class RemoveCartItemCommand: IRequest
{
    public Guid ProductId { get; set; }
}