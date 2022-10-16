using Microsoft.AspNetCore.Identity;

namespace Rating_University.Data
{
    public class Rating_UniversityRoles : IdentityRole
    {
        public Rating_UniversityRoles() : base() { }

        public Rating_UniversityRoles(string name)
            : base(name)
        { }
    }
}
