using System.ComponentModel.DataAnnotations;

namespace Rating_University.Features.Identity.Model
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
