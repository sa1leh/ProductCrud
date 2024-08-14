using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductCURD.Categories
{
    public interface ICategoriesAppService : ICrudAppService
        <CategoryDto, int, PagedAndSortedResultRequestDto, CreateUpdateDto>
    {
    }

}
