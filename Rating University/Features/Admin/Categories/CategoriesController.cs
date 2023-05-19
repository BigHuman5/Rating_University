using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rating_University.Features.Admin.Categories.Model;

namespace Rating_University.Features.Admin.Categories
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class CategoriesController :ApiController
    {
        private readonly ICategoryServices categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        /// <summary>
        /// Получения списка всех категорий
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> All()
        {

            var result = await categoryServices.All();
            return Ok(result);
        }

        /// <summary>
        /// Создание категории
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoriesRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await categoryServices.Create(model);
                if (result.Failure)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result);
            }
            return BadRequest();

        }
    }
}
