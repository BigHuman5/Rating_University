using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rating_University.Data.Models
{
    public class User : IdentityUser<int>
    {
        public string? FullName { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
