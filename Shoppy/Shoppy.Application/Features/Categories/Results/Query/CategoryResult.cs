namespace Shoppy.Application.Features.Categories.Results.Query;

public class CategoryResult
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;
}