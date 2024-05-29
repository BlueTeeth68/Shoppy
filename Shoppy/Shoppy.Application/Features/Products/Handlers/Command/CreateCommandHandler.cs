using MediatR;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Products.Handlers.Command;

public class CreateCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductService _productService;

    public CreateCommandHandler(IProductService productService)
    {
        _productService = productService;
    }


    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var id = await _productService.CreateAsync(request, cancellationToken);

        return id;
    }
}