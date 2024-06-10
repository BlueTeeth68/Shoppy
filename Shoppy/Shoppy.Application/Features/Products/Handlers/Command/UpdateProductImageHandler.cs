using MediatR;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Shoppy.Application.Features.Products.Handlers.Command;

public class UpdateProductImageHandler: IRequestHandler<UpdateProductImageCommand, string>
{
    private readonly IProductService _productService;

    public UpdateProductImageHandler(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<string> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
    {
        var result = await _productService.UpdateProductThumbAsync(request, cancellationToken);
        return result;
    }
}