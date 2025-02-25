using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Catalog.Dtos.ProductDetailDtos;
using ZCommerce.Catalog.Services.ProductDetailServices;

namespace ZCommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCategories()
        {
            var categories = await _ProductDetailService.GetAllProductDetailAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var ProductDetail = await _ProductDetailService.GetProductDetailByIdAsync(id);
            return Ok(ProductDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            var ProductDetail = await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok(ProductDetail);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string ProductDetailId)
        {
            var result = await _ProductDetailService.DeleteProductDetailAsync(ProductDetailId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var ProductDetail = await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok(ProductDetail);
        }
    }
}
