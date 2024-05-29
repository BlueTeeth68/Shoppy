using MediatR;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Products.Handlers.Command;

public class UpdateCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductService _productService;

    public UpdateCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(request, cancellationToken);
    }
}