using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rating_University.Features.Admin.Accounts.Model;

namespace Rating_University.Features.Admin.Accounts
{
    [Authorize]
    public class AccountController : ApiController
    {
        private readonly IAccountServices accountServices;

        public AccountController(IAccountServices accountServices)
        {
            this.accountServices = accountServices;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create(CreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var createNewUser = await accountServices.Create(model);

                if (createNewUser.Failure)
                {
                    return BadRequest(createNewUser.Message);
                }

                return Ok(createNewUser.Message);
            }

            return BadRequest();
        }
    }
}
