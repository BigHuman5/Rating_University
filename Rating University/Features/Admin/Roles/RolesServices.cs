
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public RolesServices(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable> All()
        {
            return roleManager.Roles.ToList();
        }

        public async Task<Result> Create(CreateRoleRequestModel model)
        {
            var role = new Role
            {
                Name = model.RoleName,
            };
            var result = await roleManager.CreateAsync(role);

            if(!result.Succeeded)
            {
                return "Ошибка добавления роли";
            }

            return true;
        }
    }
}
