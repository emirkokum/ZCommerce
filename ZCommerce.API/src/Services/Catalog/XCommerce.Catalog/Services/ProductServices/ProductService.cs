using AutoMapper;
using MongoDB.Driver;
using ZCommerce.Catalog.Dtos.ProductDtos;
using ZCommerce.Catalog.Entities;
using ZCommerce.Catalog.Settings;

namespace ZCommerce.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        private readonly IMongoCollection<Product> _productCollection;

        public Task<ResultProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _productCollection.InsertOneAsync(values);
            return Task.FromResult(_mapper.Map<ResultProductDto>(values));
        }

        public async Task<bool> DeleteProductAsync(string ProductId)
        {
            var deleteResult = await _productCollection.DeleteOneAsync(x => x.ProductId == ProductId);
            return deleteResult.DeletedCount > 0;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<ResultProductDto> GetProductByIdAsync(string id)
        {
            var values = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDto>(values);
        }

        public async Task<ResultProductDto> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
            return _mapper.Map<ResultProductDto>(values);
        }
    }
}
