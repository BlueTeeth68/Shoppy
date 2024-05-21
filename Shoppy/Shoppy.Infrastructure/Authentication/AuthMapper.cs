using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.Persistence.Identity;

namespace Shoppy.Infrastructure.Authentication;

public static class AuthMapper
{
    public static LoginResponse UserToLoginResult(AppUser entity)
        => new LoginResponse()
        {
            Id = entity.Id,
            Email = entity.Email,
            FullName = entity.FullName,
            PictureUrl = entity.PictureUrl
        };
}