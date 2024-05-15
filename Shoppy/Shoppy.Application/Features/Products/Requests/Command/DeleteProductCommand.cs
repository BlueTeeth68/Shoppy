using MediatR;

namespace Shoppy.Application.Features.Products.Requests.Command;

public record DeleteProductCommand(Guid Id) : IRequest;