using AutoMapper;
using MongoDB.Driver;
using ZCommerce.Catalog.Dtos.CategoryDtos;
using ZCommerce.Catalog.Entities;
using ZCommerce.Catalog.Settings;

namespace ZCommerce.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<ResultCategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return _mapper.Map<ResultCategoryDto>(category);
        }


        public async Task<bool> DeleteCategoryAsync(string categoryId)
        {
            var deleteResult = await _categoryCollection.DeleteOneAsync(x => x.CategoryId == categoryId);
            return deleteResult.DeletedCount > 0;
        }


        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return  _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<ResultCategoryDto> GetCategoryByIdAsync(string id)
        {
            var values = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultCategoryDto>(values);
        }

        public async Task<ResultCategoryDto> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
            return _mapper.Map<ResultCategoryDto>(values);
        }
    }
}
