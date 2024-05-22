using MediatR;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Shoppy.Application.Features.Carts.Request.Query;

public class GetUserCartDetailQuery: IRequest<CartDto>
{
}