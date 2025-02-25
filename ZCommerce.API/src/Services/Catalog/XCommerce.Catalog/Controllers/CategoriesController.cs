using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Catalog.Dtos.CategoryDtos;
using ZCommerce.Catalog.Services.CategoryServices;

namespace ZCommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCategories()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok(category);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            var result = await _categoryService.DeleteCategoryAsync(categoryId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok(category);
        }
    }
}
