using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rating_University.Data.Models;

namespace Rating_University.Data
{
    // Класс для бд. В <...> int для перевода Id c string в int
    public class Rating_UniversityDbContext : IdentityDbContext<
        IdentityUser<int>,
        IdentityRole<int>, int>
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public Rating_UniversityDbContext(DbContextOptions options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasOne(c => c.Role)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
