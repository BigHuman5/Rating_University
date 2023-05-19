using Microsoft.EntityFrameworkCore;
using Rating_University.Data;
using Rating_University.Data.Models;
using Rating_University.Features.Admin.Categories.Model;
using Rating_University.Infrastructure.Services;
using System.Collections;

namespace Rating_University.Features.Admin.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly Rating_UniversityDbContext data;
        private readonly ICurrentUserServices currentUserServices;
        private readonly IRolesServices rolesServices;

        public CategoryServices(Rating_UniversityDbContext data,
            ICurrentUserServices currentUserServices,
            IRolesServices rolesServices)
        {
            this.data = data;
            this.currentUserServices = currentUserServices;
            this.rolesServices = rolesServices;
        }

        /// <summary>
        /// Список всех категорий
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> All()
        {
            return await this.data
                .Categories.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Создание категории
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result> Create(CreateCategoriesRequestModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                if (!rolesServices.IsAdmin.Result)
                {
                    return "У вас нет доступа!";
                }
                var CheckRole = await this.data.Roles.FirstOrDefaultAsync(p => p.Id == model.Role);

                if (CheckRole == null)
                {
                    return "Роль не найдена";
                }

                Category categories = new Category
                {
                    Name = model.Name,
                    RoleId = model.Role
                };

                data.Categories.Add(categories);

                await data.SaveChangesAsync();
                return true;
            }
            return "Ошибка в названии";

        }
    }
}
