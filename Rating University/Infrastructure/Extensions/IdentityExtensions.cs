using System.Security.Claims;

namespace Rating_University.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
                .Value;
        }

        public static string? GetRoleId(this ClaimsPrincipal user)
        {
            return user.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role)?
                .Value;
        }
    }
}
