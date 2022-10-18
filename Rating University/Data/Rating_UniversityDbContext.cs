using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rating_University.Data.Models;

namespace Rating_University.Data
{
    // Класс для бд. В <...> int для перевода Id c string в int
    public class Rating_UniversityDbContext : IdentityDbContext<
        User,
        Role, int>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }


        public Rating_UniversityDbContext(DbContextOptions options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*builder
                .Entity<User>()
                .HasOne(c => c.Role)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);*/

            builder
                .Entity<Category>()
                .HasOne(c => c.Role)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<ItemCategory>()
                .HasOne(c => c.Category)
                .WithMany(u => u.ItemCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<ItemCategory>()
                .HasOne(c => c.User)
                .WithMany(u => u.ItemCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
