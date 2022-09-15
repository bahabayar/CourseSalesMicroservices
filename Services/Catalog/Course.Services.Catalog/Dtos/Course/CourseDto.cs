using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSales.Services.Catalog.Dtos
{
    internal class CourseDto
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public FeatureDto Feature { get; set; }
    }
}
