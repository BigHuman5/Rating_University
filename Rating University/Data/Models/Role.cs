using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rating_University.Data.Models
{
    public class Role : IdentityRole<int>
    {
        public bool isAdmin { get; set; } = false;

        public IEnumerable<Category> Categories { get; set; }
    }
}
