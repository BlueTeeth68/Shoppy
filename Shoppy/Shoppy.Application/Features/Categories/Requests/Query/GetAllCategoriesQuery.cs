using MediatR;
using Shoppy.Application.Features.Categories.Results.Query;

namespace Shoppy.Application.Features.Categories.Requests.Query;

public record GetAllCategoriesQuery(): IRequest<List<CategoryResult>>;