using ZCommerce.Catalog.Dtos.ProductDetailDtos;

namespace ZCommerce.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<ResultProductDetailDto> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task<bool> DeleteProductDetailAsync(string productDetailId);
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<ResultProductDetailDto> GetProductDetailByIdAsync(string productDetailId);
        Task<ResultProductDetailDto> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
    }
}
