using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Rating_University.Features.Identity.Model;
using Rating_University.Infrastructure.Services;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Rating_University.Data.Models;


namespace Rating_University.Features.Identity
{
    using Rating_University.Data;
    using Rating_University.Features.Admin.Accounts.Model;

    public class IdentitryServices : IIdentityServices
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly Rating_UniversityDbContext data;

        public IdentitryServices(Rating_UniversityDbContext data, RoleManager<Role> roleManager, UserManager<User> userManager, AuthorizationContext context)
        {
            this.data = data;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="model"></param>
        /// <param name="appSettings"></param>
        /// <returns></returns>
        public async Task<ActionResult<LoginResponseModel>> Login(
            LoginRequestModel model,
            AppSettings appSettings)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return null;
            }

            var password = await userManager.CheckPasswordAsync(user, model.Password);

            if (!password)
            {
                return null;
            }

            int role = await this.data.User
                .Where(p=> p.Id == user.Id)
                .Select(r=>r.Id)
                .Intersect(data.UserRoles.Select(r=>r.UserId))
                .FirstOrDefaultAsync();

            var token = GenerateJwtToken(
                                        user.Id,
                                        user.UserName,
                                        role,
                                        appSettings.Secret);
            //
            new Claim("Role","Read");
            
            //
            return new LoginResponseModel
            {
                Token = token
            };
        }

        public string GenerateJwtToken(int userId, string userName, int RoleId, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, RoleId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
