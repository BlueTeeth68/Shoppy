using Shoppy.Persistence.Identity;

namespace Shoppy.Infrastructure.Web.Authentication;

public interface IJwtTokenGenerator
{
    Task<string> GenerateAccessTokenAsync(AppUser user);
    Task<string> GenerateRefreshTokenAsync(AppUser user);
}