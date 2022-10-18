using Rating_University.Features.Users.Model;
using System.Collections;

namespace Rating_University.Features.Users
{
    public interface IUserservices
    {
        Task<IEnumerable<AllUserResponceModel>> All();

        Task<UserResponceModel> Mine(int id);
        Task<UserResponceModel> ByUser(int id);
    }
}
