using AutoMapper;
using CourseSales.Services.Catalog.Dtos;
using CourseSales.Services.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSales.Services.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            /*Base*/
            CreateMap<Models.Course, CourseDto >().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto >().ReverseMap();

            /*CourseDto*/
            CreateMap<Models.Course, CourseCreateDto>().ReverseMap();
            CreateMap<Models.Course, CourseUpdateDto>().ReverseMap();
            /*CategoryDto*/

            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();


        }
    }
}
