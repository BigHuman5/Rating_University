using System.ComponentModel.DataAnnotations;

namespace Rating_University.Features.Admin.Roles.Model
{
    public class CreateRoleRequestModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
