using Rating_University.Infrastructure.Extensions;

namespace Rating_University.Infrastructure.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly RoleExtensions role;

        public RolesServices(RoleExtensions role)
        {
            this.role = role;
        }

        public async Task<bool> IsAdmin() => await role.isAdmin();
    }
}
