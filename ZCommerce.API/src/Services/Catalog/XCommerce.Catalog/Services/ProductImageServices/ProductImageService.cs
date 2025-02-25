using AutoMapper;
using MongoDB.Driver;
using ZCommerce.Catalog.Dtos.ProductImageDtos;
using ZCommerce.Catalog.Entities;
using ZCommerce.Catalog.Settings;

namespace ZCommerce.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task<ResultProductImageDto> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(productImage);
            return _mapper.Map<ResultProductImageDto>(productImage);
        }

        public async Task<bool> DeleteProductImageAsync(string productImageId)
        {
            var deleteResult = await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == productImageId);
            return deleteResult.DeletedCount > 0;
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var productImages = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(productImages);
        }

        public async Task<ResultProductImageDto> GetProductImageByIdAsync(string productImageId)
        {
            var productImage = await _productImageCollection.Find(x => x.ProductImageId == productImageId).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductImageDto>(productImage);
        }

        public async Task<ResultProductImageDto> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, productImage);
            return _mapper.Map<ResultProductImageDto>(productImage);
        }
    }
}
