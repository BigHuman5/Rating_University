
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rating_University.Data;
using Rating_University.Data.Models;
using Rating_University.Features.Admin.Roles.Model;
using Rating_University.Infrastructure.Services;
using System.Collections;

namespace Rating_University.Features.Admin.Roles
{
    public class RolesServices : IRolesServices
    {
        private readonly RoleManager<Role> roleManager;
        private readonly Rating_UniversityDbContext data;
        private readonly ICurrentUserServices currentUserServices;
        private readonly Infrastructure.Services.IRolesServices rolesServices;

        public RolesServices(Rating_UniversityDbContext data,
            ICurrentUserServices currentUserServices,
            RoleManager<Role> roleManager,
            Infrastructure.Services.IRolesServices rolesServices)
        {
            this.data = data;
            this.currentUserServices = currentUserServices;
            this.roleManager = roleManager;
            this.rolesServices = rolesServices;
        }
        /// <summary>
        /// Просмотр всех ролей
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> All()
        {
            return await roleManager.Roles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Создание роли
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result> Create(CreateRoleRequestModel model)
        {
            if (!rolesServices.IsAdmin.Result)
            {
                return "У вас нет доступа!";
            }
            var role = new Role
            {
                Name = model.RoleName,
            };
            try
            {
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    return "Ошибка добавления роли";
                }

                return true;
            }
            catch
            {
                return "Ошибка добавления роли";
            }
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            if (!rolesServices.IsAdmin.Result)
            {
                return "У вас нет доступа!";
            }

            var isRole = await this.data
                                  .Role
                                  .Where(i => i.Id == id).AnyAsync();

            if (!isRole)
            {
                return "Не удалось найти такую роль";
            }

            var role = await roleManager.FindByIdAsync(id.ToString());

            var del = await roleManager.DeleteAsync(role);

            if(del.Succeeded)
            {
                return true;
            }

            return del.Errors.FirstOrDefault().ToString();
        }

        /*Не раб*/
        /// <summary>
        /// Проверка на то, может ли пользовательь это делать
        /// </summary>
        /// <returns></returns>
            private async Task<bool> isCan()
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
