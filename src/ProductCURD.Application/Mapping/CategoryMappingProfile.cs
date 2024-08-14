using AutoMapper;
using ProductCURD.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCURD.Mapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile() {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateUpdateDto, Category>();
        
        }
    }
}
