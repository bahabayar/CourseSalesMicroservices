using CourseSales.Services.Catalog.Dtos;
using CourseSales.Services.Catalog.Services.Interfaces;
using CourseSales.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseSales.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllByUserIdAsync(string id)
        {
            var response = await _courseService.GetAllByUserIdAsync(id);
            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto model)
        {
            var response = await _courseService.CreateAsync(model);
            return CreateActionResultInstance(response);
        }
        [HttpPut]
        public async Task<IActionResult> Create(CourseUpdateDto model)
        {
            var response = await _courseService.UpdateAsync(model);
            return CreateActionResultInstance(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }

    }
}
