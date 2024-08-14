using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProductCURD.products
{
    public interface IProductAppService
    {
        Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input);
        Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input);
        Task<ProductDto> GetProductAsync(int id);
        Task<bool> DeleteProductAsync(int id);
        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input);
    }
}
