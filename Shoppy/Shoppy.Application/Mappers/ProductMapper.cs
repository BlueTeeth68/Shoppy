using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Application.Utils;
using Shoppy.Domain.Entities;

namespace Shoppy.Application.Mappers;

public static class ProductMapper
{
    public static Product CreateProductCommandToProduct(CreateProductCommand dto)
        => new Product()
        {
            Name = dto.Name,
            Description = dto.Description,
            Sku = dto.Sku,
            AuthorName = dto.AuthorName,
            Publisher = dto.Publisher,
            NumberOfPage = dto.NumberOfPage,
            DateOfPublication = dto.DateOfPublication,
            Price = dto.Price,
            Quantity = dto.Quantity,
            CategoryId = dto.CategoryId
        };


    public static ProductDetailQueryResult ProductToProductDetail(Product entity)
    {
        return new ProductDetailQueryResult()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Sku = entity.Sku,
            AuthorName = entity.AuthorName,
            Publisher = entity.Publisher,
            NumberOfPage = entity.NumberOfPage,
            DateOfPublication = entity.DateOfPublication,
            Price = entity.Price,
            Quantity = entity.Quantity,
            Status = entity.Status,
            AvgRate = entity.AvgRate,
            NumberOfSale = entity.NumberOfSale,
            ProductThumbUrl = entity.ProductThumbUrl,
            CategoryId = entity.CategoryId,
            CategoryName = entity.Category?.Name
        };
    }
}