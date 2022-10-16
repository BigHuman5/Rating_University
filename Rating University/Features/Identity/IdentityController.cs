using Microsoft.AspNetCore.Mvc;
using Rating_University.Features.Identity.Model;

namespace Rating_University.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityServices _identityServices;
        private readonly AppSettings appSettings;

        public IdentityController(IIdentityServices identityServices,
            AppSettings appSettings)
        {
            _identityServices = identityServices;
            this.appSettings = appSettings;
        }

        [HttpPost]
        [Route(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create(CreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var createNewUser = await _identityServices.Create(model);

                if(createNewUser.Failure)
                {
                    return BadRequest(createNewUser.Message);
                }

                return Ok(createNewUser.Message);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route(nameof(Login))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _identityServices.Login(model,appSettings);

                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok();
            }

            return BadRequest();
        }
    }
}
