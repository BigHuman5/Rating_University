using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rating_University.Features.Users.Model;
using Rating_University.Infrastructure.Services;

namespace Rating_University.Features.Users
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserservices userservices;
        private readonly ICurrentUserServices currentUserServices;

        public UserController(IUserservices userservices, ICurrentUserServices currentUserServices)
        {
            this.userservices = userservices;
            this.currentUserServices = currentUserServices;
        }

        /// <summary>
        /// Получения списка всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AllUserResponceModel>> All()
        {
            var result = await userservices.All();
            return Ok(result);
        }

        /// <summary>
        /// Получения информации о своём аккаунте
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<UserResponceModel>> Index()
        {
            int id = currentUserServices.getIdUser();
            var result = await userservices.Mine(id);
            return Ok(result);
        }

        /// <summary>
        /// Получения информации о чужом аккаунте
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserResponceModel>> ByUser(int id)
        {
            var result = await userservices.ByUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
