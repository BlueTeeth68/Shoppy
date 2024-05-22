using MediatR;
using Shoppy.SharedLibrary.Models.Requests.Carts;

namespace Shoppy.Application.Features.Carts.Request.Command;

public class UpdateCartItemCommand: UpdateCartItemDto, IRequest
{
    
}