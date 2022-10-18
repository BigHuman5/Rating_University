using System.ComponentModel.DataAnnotations;

namespace Rating_University.Data.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public IEnumerable<ItemCategory> ItemCategories { get; set; }
    }
}
