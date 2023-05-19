using Rating_University.Infrastructure.Extensions;
using System.Security.Claims;

namespace Rating_University.Infrastructure.Services
{
    public class CurrentUserServices : ICurrentUserServices
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ClaimsPrincipal user;

        public CurrentUserServices(IHttpContextAccessor contextAccessor)
        {
            this.user = contextAccessor.HttpContext?.User;
        }

        public int getIdUser()
        {
            var Id = user.GetId();
            if (Id != null)
            {
                int parseId = int.Parse(Id);

                if (parseId == -1)
                {
                    return -1;
                }
                return parseId;
            }
            return -1;
        }

        public string? getNameUser()
        {
            return user?
                .Identity?
                .Name;
        }

        public int getRoleUser()
        {
            var Id = user.GetRoleId();
            if (Id != null)
            {
                int parseId = int.Parse(Id);

                if (parseId == -1)
                {
                    return -1;
                }
                return parseId;
            }
            return -1;
        }
    }
}
