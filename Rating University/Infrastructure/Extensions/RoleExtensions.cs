using Microsoft.EntityFrameworkCore;
using Rating_University.Data;
using Rating_University.Infrastructure.Services;

namespace Rating_University.Infrastructure.Extensions
{
    public class RoleExtensions
    {
        private readonly Rating_UniversityDbContext data;
        private readonly ICurrentUserServices currentUserServices;

        public RoleExtensions(Rating_UniversityDbContext data, ICurrentUserServices currentUserServices)
        {
            this.data = data;
            this.currentUserServices = currentUserServices;
        }

        /// <summary>
        /// Проверка на то, может ли пользовательь это делать
        /// </summary>
        /// <returns></returns>
        public async Task<bool> isAdmin()
        {
            int RoleId = currentUserServices.getRoleUser();

            var result = await this.data
                .Role
                .AsNoTracking()
                .Where(w => w.Id == RoleId)
                .Select(r => r.isAdmin)
                .FirstOrDefaultAsync();

            if (!result)
            {
                return false;
            }
            return true;
        }
    }
}
