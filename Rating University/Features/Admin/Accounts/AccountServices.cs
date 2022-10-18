using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rating_University.Data;
using Rating_University.Data.Models;
using Rating_University.Features.Admin.Accounts.Model;
using Rating_University.Infrastructure.Services;

namespace Rating_University.Features.Admin.Accounts
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<User> userManager;
        private readonly Rating_UniversityDbContext data;
        private readonly IRolesServices rolesServices;

        public AccountServices(UserManager<User> userManager, Rating_UniversityDbContext data, IRolesServices rolesServices)
        {
            this.userManager = userManager;
            this.data = data;
            this.rolesServices = rolesServices;
        }
        /// <summary>
        /// Создание нового аккаунта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task<Result> Create(CreateRequestModel model)
        {
            if(!rolesServices.IsAdmin.Result)
            {
                return "У вас нет доступа!";
            }
            var user = new User
            {
                UserName = model.Login,
                FullName = model.FullName,
            };

            var getRoleName = await this.data
                                  .Role
                                  .Where(i => i.Id == model.RoleId)
                                  .Select(n => n.Name)
                                  .FirstOrDefaultAsync();

            if (getRoleName == null)
            {
                return "Не удалось найти такую роль";
            }

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return result.ToString();
            }

            var role = await userManager.AddToRoleAsync(user, getRoleName);

            if (role.Succeeded)
            {
                return true;
            }

            return "Не удалось найти такую роль.";

        }
    }
}
