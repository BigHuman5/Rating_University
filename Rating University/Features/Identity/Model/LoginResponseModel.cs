using System.ComponentModel.DataAnnotations;

namespace Rating_University.Features.Identity.Model
{
    public class LoginResponseModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
