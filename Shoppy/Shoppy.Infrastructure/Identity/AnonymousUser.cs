using Shoppy.Domain.Identity;

namespace Shoppy.Infrastructure.Identity;

public class AnonymousUser : ICurrentUser
{
    public bool IsAuthenticated => false;
    public Guid UserId => Guid.Empty;
}