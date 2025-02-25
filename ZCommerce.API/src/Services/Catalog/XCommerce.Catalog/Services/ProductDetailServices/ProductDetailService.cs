using AutoMapper;
using MongoDB.Driver;
using ZCommerce.Catalog.Dtos.ProductDetailDtos;
using ZCommerce.Catalog.Entities;
using ZCommerce.Catalog.Settings;

namespace ZCommerce.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task<ResultProductDetailDto> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(productDetail);
            return _mapper.Map<ResultProductDetailDto>(productDetail);
        }

        public async Task<bool> DeleteProductDetailAsync(string productDetailId)
        {
            var deleteResult = await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == productDetailId);
            return deleteResult.DeletedCount > 0;
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<ResultProductDetailDto> GetProductDetailByIdAsync(string productDetailId)
        {
            var productDetail = await _productDetailCollection.Find(x => x.ProductDetailId == productDetailId).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDetailDto>(productDetail);
        }

        public async Task<ResultProductDetailDto> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, productDetail);
            return _mapper.Map<ResultProductDetailDto>(productDetail);
        }
    }
}
