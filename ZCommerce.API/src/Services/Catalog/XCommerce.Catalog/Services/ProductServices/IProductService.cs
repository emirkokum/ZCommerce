using ZCommerce.Catalog.Dtos.ProductDtos;

namespace ZCommerce.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<ResultProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ResultProductDto> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ResultProductDto> GetProductByIdAsync(string id);
        Task<bool> DeleteProductAsync(string ProductId);

    }
}
