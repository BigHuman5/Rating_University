using Rating_University.Features.Admin.Categories.Model;
using Rating_University.Infrastructure.Services;
using System.Collections;

namespace Rating_University.Features.Admin.Categories
{
    public interface ICategoryServices
    {
        Task<IEnumerable> All();

        Task<Result> Create(CreateCategoriesRequestModel model);
    }
}
