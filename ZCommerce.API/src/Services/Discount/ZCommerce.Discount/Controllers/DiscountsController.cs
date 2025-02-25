using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Discount.Dtos;
using ZCommerce.Discount.Services;

namespace ZCommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCouponAsync()
        {
            var result = await _discountService.GetAllCouponAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCouponAsync(GetByIdCouponDto getByIdCouponDto)
        {
            var result = await _discountService.GetByIdCouponAsync(getByIdCouponDto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            var result = await _discountService.CreateCouponAsync(createCouponDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouponAsync(int id)
        {
            var result = await _discountService.DeleteCouponAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            var result = await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok(result);
        }
    }
}
