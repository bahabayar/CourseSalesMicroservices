using CourseSales.Services.Catalog.Dtos;
using CourseSales.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSales.Services.Catalog.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto model);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
