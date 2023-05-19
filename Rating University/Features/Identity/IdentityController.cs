using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Rating_University.Features.Admin.Accounts.Model;
using Rating_University.Features.Identity.Model;

namespace Rating_University.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityServices _identityServices;
        private readonly AppSettings appSettings;

        public IdentityController(IIdentityServices identityServices,
            IOptions<AppSettings> appSettings)
        {
            _identityServices = identityServices;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
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

                return Ok(user.Value);
            }

            return BadRequest();
        }
    }
}
