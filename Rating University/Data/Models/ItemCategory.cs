using System.ComponentModel.DataAnnotations;

namespace Rating_University.Data.Models
{
    public class ItemCategory
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Points { get; set; } = 0;
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
