using System.ComponentModel.DataAnnotations;
using Shoppy.Domain.Constants.Enums;

namespace Shoppy.SharedLibrary.Models.Requests.Products;

public class FilterProductRequest
{
    [MaxLength(250)] public string? Name { get; set; }
    public ProductStatus? Status { get; set; }
    public Guid? CategoryId { get; set; }
    [MaxLength(10)] public string? SortName { get; set; }
    [MaxLength(10)] public string? SortPrice { get; set; }
    [MaxLength(10)] public string? SortAvgRate { get; set; }
    [MaxLength(10)] public string? SortNumberOfSale { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }
}