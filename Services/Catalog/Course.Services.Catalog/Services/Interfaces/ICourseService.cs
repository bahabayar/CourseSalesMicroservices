using CourseSales.Services.Catalog.Dtos;
using CourseSales.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSales.Services.Catalog.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto model);
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto model);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
