using Dapper;
using System.Reflection.Metadata;
using ZCommerce.Discount.Context;
using ZCommerce.Discount.Dtos;

namespace ZCommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<ResultCouponDto> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, isActive, ValidDate) VALUES (@Code, @Rate, @isActive, @ValidDate) RETURNING *";
            var parameters = new DynamicParameters();
            parameters.Add("Code", createCouponDto.Code);
            parameters.Add("Rate", createCouponDto.Rate);
            parameters.Add("isActive", createCouponDto.isActive);
            parameters.Add("ValidDate", createCouponDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync(query, parameters);
                return value;
            }
        }

        public async Task<ResultCouponDto> DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultCouponDto> GetByIdCouponAsync(GetByIdCouponDto getByIdCouponDto)
        {
            string query = "SELECT * FROM Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", getByIdCouponDto.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query);
                return values;
            }
        }

        public async Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = @"UPDATE Coupons 
                     SET Code = @Code, 
                         Rate = @Rate, 
                         IsActive = @IsActive, 
                         ValidDate = @ValidDate 
                     WHERE CouponId = @CouponId";

            var parameters = new DynamicParameters();
            parameters.Add("Code", updateCouponDto.Code);
            parameters.Add("Rate", updateCouponDto.Rate);
            parameters.Add("IsActive", updateCouponDto.IsActive);
            parameters.Add("ValidDate", updateCouponDto.ValidDate);
            parameters.Add("CouponId", updateCouponDto.CouponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                int affectedRows = await connection.ExecuteAsync(query, parameters);
                return affectedRows > 0; // Güncelleme başarılıysa true döner.
            }
        }

    }
}
