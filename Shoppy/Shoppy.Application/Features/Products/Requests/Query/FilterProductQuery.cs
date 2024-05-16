using System.ComponentModel.DataAnnotations;
using MediatR;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Application.Features.Products.Requests.Query;

public class FilterProductQuery : IRequest<PagingResult<FilterProductResult>>
{
    [MaxLength(250)] public string? Name { get; set; }
    public ProductStatus? Status { get; set; }
    [MaxLength(10)] public string? SortName { get; set; }
    [MaxLength(10)] public string? SortPrice { get; set; }
    [MaxLength(10)] public string? SortAvgRate { get; set; }
    [MaxLength(10)] public string? SortNumberOfSale { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }
}