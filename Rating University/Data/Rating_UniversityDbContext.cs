using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Rating_University.Data
{
    // Класс для бд. В <...> int для перевода Id c string в int
    public class Rating_UniversityDbContext : IdentityDbContext<
        IdentityUser<int>,
        IdentityRole<int>, int>
    {
        public Rating_UniversityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }

    }
}
