using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Catalog.Dtos.ProductDtos;
using ZCommerce.Catalog.Services.ProductServices;

namespace ZCommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCategories()
        {
            var categories = await _productService.GetAllProductAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetproductById(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Createproduct(CreateProductDto createproductDto)
        {
            var product = await _productService.CreateProductAsync(createproductDto);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Deleteproduct(string productId)
        {
            var result = await _productService.DeleteProductAsync(productId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Updateproduct(UpdateProductDto updateproductDto)
        {
            var product = await _productService.UpdateProductAsync(updateproductDto);
            return Ok(product);
        }
    }
}
