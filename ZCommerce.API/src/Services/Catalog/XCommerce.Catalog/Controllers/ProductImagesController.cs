using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Catalog.Dtos.ProductImageDtos;
using ZCommerce.Catalog.Services.ProductImageServices;

namespace ZCommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _productImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProductImages()
        {
            var ProductImageies = await _productImageService.GetAllProductImagesAsync();
            return Ok(ProductImageies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var ProductImage = await _productImageService.GetProductImageByIdAsync(id);
            return Ok(ProductImage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            var ProductImage = await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok(ProductImage);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string ProductImageId)
        {
            var result = await _productImageService.DeleteProductImageAsync(ProductImageId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var ProductImage = await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok(ProductImage);
        }
    }
}
