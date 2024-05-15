using MediatR;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Application.Features.Users.Requests.Query;

public class FilterUserQuery : IRequest<PagingResult<FilterUserResult>>
{
    public string? Name { get; set; }

    public Gender? Gender { get; set; }

    public UserStatus? Status { get; set; }

    public string? SortName { get; set; }

    public string? SortCreatedDate { get; set; }

    public int? Page { get; set; }
    public int? Size { get; set; }
}