using Microsoft.AspNetCore.Mvc;
using Rating_University.Data.Models;
using Rating_University.Features.Admin.Roles.Model;
using Rating_University.Infrastructure.Services;
using System.Collections;

namespace Rating_University.Features.Admin.Roles
{
    public interface IRolesServices
    {
        Task<IEnumerable> All();

        Task<Result> Create(CreateRoleRequestModel model);
    }
}
