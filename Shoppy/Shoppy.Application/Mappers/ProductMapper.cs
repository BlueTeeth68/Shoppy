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

    public static void UpdateProductToEntity(UpdateProductCommand dto, ref Product entity)
    {
        if (!string.IsNullOrEmpty(dto.Name))
        {
            entity.Name = dto.Name;
        }

        if (!string.IsNullOrEmpty(dto.Description))
        {
            entity.Description = dto.Description;
        }

        if (!string.IsNullOrEmpty(dto.AuthorName))
        {
            entity.AuthorName = dto.AuthorName;
        }

        if (!string.IsNullOrEmpty(dto.Publisher))
        {
            entity.Publisher = dto.Publisher;
        }

        if (dto.NumberOfPage.HasValue)
        {
            entity.NumberOfPage = dto.NumberOfPage.Value;
        }

        if (dto.DateOfPublication.HasValue)
        {
            entity.DateOfPublication = dto.DateOfPublication.Value;
        }

        if (dto.Price.HasValue)
        {
            entity.Price = dto.Price.Value;
        }

        if (dto.CategoryId.HasValue)
        {
            entity.CategoryId = dto.CategoryId.Value;
        }
    }
}