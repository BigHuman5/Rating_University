using Microsoft.AspNetCore.Mvc;

namespace Rating_University.Features.Identity
{
    public class IdentityController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            return Ok(id);
        }
    }
}
