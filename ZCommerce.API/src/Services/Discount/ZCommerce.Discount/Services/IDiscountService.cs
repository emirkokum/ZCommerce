using ZCommerce.Discount.Dtos;

namespace ZCommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task<ResultCouponDto> CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<ResultCouponDto> DeleteCouponAsync(int id);
        Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<ResultCouponDto> GetByIdCouponAsync(GetByIdCouponDto getByIdCouponDto);
    }
}
