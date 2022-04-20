using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers
{
    
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //api/categories/GetSingleCategoryByWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByWithProductsAsync(categoryId));
        }

    }
}
