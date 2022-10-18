using Rating_University.Features.Admin.Accounts.Model;
using Rating_University.Infrastructure.Services;

namespace Rating_University.Features.Admin.Accounts
{
    public interface IAccountServices
    {
        Task<Result> Create(CreateRequestModel model);
    }
}
