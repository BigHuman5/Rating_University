using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Rating_University.Data;
using Rating_University.Data.Models;
using Rating_University.Features.Identity.Model;
using Rating_University.Infrastructure.Services;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Rating_University.Features.Identity
{
    public class IdentitryServices : IIdentityServices
    {
        private readonly UserManager<User> userManager;
        private readonly Rating_UniversityDbContext data;

        public IdentitryServices(Rating_UniversityDbContext data)
        {
            this.data = data;
        }

        public async Task<Result> Create(CreateRequestModel model)
        {
            var user = new User
            {
                UserName = model.Login,
                FullName = model.FullName,
                RoleId = model.RoleId,
            };

            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                return true;
            }
            return "Не удалось создать пользователя";
        }

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

            var token = GenerateJwtToken(
                                        user.Id,
                                        user.UserName,
                                        user.RoleId,
                                        appSettings.Secret);

            return new LoginResponseModel
            {
                Token = token,
                RoleId = user.RoleId,
            };
        }

        public string GenerateJwtToken(int userId, string userName,int RoleId, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, userName),
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
