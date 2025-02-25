using ZCommerce.Catalog.Dtos.CategoryDtos;

namespace ZCommerce.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<ResultCategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<ResultCategoryDto> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<ResultCategoryDto> GetCategoryByIdAsync(string id);
        Task<bool> DeleteCategoryAsync(string categoryId);
    }
}
