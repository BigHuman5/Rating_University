using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rating_University.Data;
using Rating_University.Data.Models;
using Rating_University.Features.Users.Model;
using Rating_University.Infrastructure.Services;
using System.Collections;

namespace Rating_University.Features.Users
{
    public class UserServices : IUserservices
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        private readonly Rating_UniversityDbContext data;

        public UserServices(RoleManager<Role> roleManager, Rating_UniversityDbContext data, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.data = data;
            this.userManager = userManager;
        }

        /// <summary>
        /// Вывод всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllUserResponceModel>> All()
        {
            List<AllUserResponceModel> allUsers = new List<AllUserResponceModel>();

            var RolesName = await roleManager.Roles.Select(p => p.Name).ToListAsync();
            foreach(var role in RolesName)
            {
                var users = await userManager.GetUsersInRoleAsync(role);
                foreach(var user in users)
                {
                    var userInfo = new AllUserResponceModel
                    {
                        UserId = user.Id,
                        User = user.UserName,
                        Fullname = user.FullName,
                        RoleName = role,
                        TolalPoints = user.TolalPoints
                    };
                    allUsers.Add(userInfo);
                }
                
            }
            return allUsers;
        }

        /// <summary>
        /// Вывод информации о конкретном пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponceModel> ByUser(int id)
        {
            UserResponceModel model = null;
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await userManager.GetRolesAsync(user);
                model = new UserResponceModel
                {
                    UserId = user.Id,
                    User = user.UserName,
                    Fullname = user.FullName,
                    RoleName = userRoles[0],
                    TolalPoints = user.TolalPoints
                };
            }
            return model;
        }

        /// <summary>
        /// Вывод информации о себе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponceModel> Mine(int id)
        {
            UserResponceModel model = null;
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await userManager.GetRolesAsync(user);
                model = new UserResponceModel
                {
                    UserId=user.Id,
                    User = user.UserName,
                    Fullname = user.FullName,
                    RoleName = userRoles[0],
                    TolalPoints = user.TolalPoints
                };
            }
            return model;
        }
    }
}
