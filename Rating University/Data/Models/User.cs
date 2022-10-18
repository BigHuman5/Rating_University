using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rating_University.Data.Models
{
    public class User : IdentityUser<int>
    {
        public string? FullName { get; set; }

        public int TolalPoints { get; set; } = 0;

        public IEnumerable<ItemCategory> ItemCategories { get; set; }
    }
}
