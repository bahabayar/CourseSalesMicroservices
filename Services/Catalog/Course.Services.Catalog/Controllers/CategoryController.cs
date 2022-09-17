using AutoMapper;
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
    internal class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        internal CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetByIdAsync(string Id)
        { 
            var category = await _categoryService.GetByIdAsync(Id);
            return CreateActionResultInstance(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto model)
        {
            var result = await _categoryService.CreateAsync(model);
            return CreateActionResultInstance(result);
        }
    }
}
