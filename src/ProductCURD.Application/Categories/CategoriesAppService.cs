 using AutoMapper.Internal.Mappers;
using ProductCURD.Categories;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProductCURD.Categories
{
    public class CategoriesAppService : CrudAppService<Category, CategoryDto, int, PagedAndSortedResultRequestDto, CreateUpdateDto>, ICategoriesAppService
    {
        private readonly IObjectMapper _objectMapper;

        public CategoriesAppService(IRepository<Category, int> repository)
            : base(repository)
        {
           
        }
    }
}
