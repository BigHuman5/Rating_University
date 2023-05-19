using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rating_University.Data.Models;
using Rating_University.Features.Admin.Roles.Model;
using Rating_University.Infrastructure.Services;

namespace Rating_University.Features.Admin.Roles
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class RolesController : ApiController
    {
        private readonly IRolesServices rolesServices;

        public RolesController(IRolesServices rolesServices)
        {
            this.rolesServices = rolesServices;
        }

        /// <summary>
        /// Получения списка всех ролей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> All()
        {


            var result = await rolesServices.All();
            return Ok(result);
        }

        /// <summary>
        /// Создание роли
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await rolesServices.Create(model);
                if (result.Failure)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result);
            }
            return BadRequest();
            
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
                var result = await rolesServices.Delete(id);
                if (result.Failure)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result);

        }
    }
}
