using ZCommerce.Catalog.Dtos.ProductImageDtos;

namespace ZCommerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<ResultProductImageDto> CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task<bool> DeleteProductImageAsync(string productImageId);
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task<ResultProductImageDto> GetProductImageByIdAsync(string productImageId);
        Task<ResultProductImageDto> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    }
}
