using AutoMapper;
using CourseSales.Services.Catalog.Dtos;
using CourseSales.Services.Catalog.Models;
using CourseSales.Services.Catalog.Services.Interfaces;
using CourseSales.Services.Catalog.Settings;
using CourseSales.Shared.Dtos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSales.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)  
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto model)
        {
            await _categoryCollection.InsertOneAsync(_mapper.Map<Category>(model));
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(model), 200);
        }
        public async Task<Response<CategoryDto>> GetByIdAsync (string id)
        {
          var category =   await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
