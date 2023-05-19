using System.ComponentModel.DataAnnotations;

namespace Rating_University.Features.Admin.Accounts.Model
{
    public class CreateRequestModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
