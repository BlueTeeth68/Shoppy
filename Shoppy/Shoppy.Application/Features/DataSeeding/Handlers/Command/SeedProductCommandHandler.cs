using MediatR;
using Shoppy.Application.Features.DataSeeding.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.DataSeeding.Handlers.Command;

public class SeedProductCommandHandler: IRequestHandler<SeedProductCommand>
{
    private IProductService _productService;

    public SeedProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Handle(SeedProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.SeedDataAsync(request.Size, request.CategoryId, cancellationToken);
    }
}