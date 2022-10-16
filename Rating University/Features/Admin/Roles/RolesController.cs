using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rating_University.Data.Models;
using Rating_University.Features.Admin.Roles.Model;
using Rating_University.Infrastructure.Services;

namespace Rating_University.Features.Admin.Roles
{
    [Route("[controller]/[action]")]
    public class RolesController : ApiController
    {
        private readonly IRolesServices rolesServices;

        public RolesController(IRolesServices rolesServices)
        {
            this.rolesServices = rolesServices;
        }
        [HttpGet]
        public async Task<ActionResult> All()
        {
            var result = await rolesServices.All();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleRequestModel model)
        {
            var result = await rolesServices.Create(model);
            if(result.Failure)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
