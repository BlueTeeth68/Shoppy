using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Application.Features.Categories.Results.Query;
using Shoppy.Application.Utils;
using Shoppy.Domain.Entities;

namespace Shoppy.Application.Mappers;

public static class CategoryMapper
{
    public static CategoryResult CategoryToCategoryResult(ProductCategory entity)
        => new CategoryResult()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description
        };

    public static List<CategoryResult> CategoryToCategoryResult(List<ProductCategory> entities)
        => entities.Select(CategoryToCategoryResult).ToList();

    public static void UpdateCategoryCommandToEntity(UpdateCategoryCommand dto, ref ProductCategory entity)
    {
        if (!string.IsNullOrEmpty(dto.Name))
        {
            entity.Name = StringUtils.FormatName(dto.Name);
        }

        if (!string.IsNullOrEmpty(dto.Description))
        {
            entity.Description = dto.Description;
        }
    }
}