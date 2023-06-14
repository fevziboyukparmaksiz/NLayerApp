using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        //Get api/product/GetSingleCategoryByIdWithProductsAsync/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }
    }
}
