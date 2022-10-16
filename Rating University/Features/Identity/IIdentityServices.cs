using Microsoft.AspNetCore.Mvc;
using Rating_University.Features.Identity.Model;
using Rating_University.Infrastructure.Services;

namespace Rating_University.Features.Identity
{
    public interface IIdentityServices
    {
        Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model,
            AppSettings appSettings);
        Task<Result> Create(CreateRequestModel model);

        string GenerateJwtToken(int userId, string userName, int RoleId, string secret);
    }
}
