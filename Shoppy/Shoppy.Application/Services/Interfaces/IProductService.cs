using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Application.Services.Interfaces;

public interface IProductService
{
    Task<PagingResult<FilterProductResult>> FilterProductAsync(FilterProductQuery request);

    Task SeedDataAsync(int size, Guid categoryId, CancellationToken cancellationToken = default);

    Task<string> UpdateProductThumbAsync(UpdateProductImageCommand request,
        CancellationToken cancellationToken = default);

    Task<Guid> CreateAsync(CreateProductCommand request, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateProductCommand request, CancellationToken cancellationToken = default);
}