/*using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductCURD.products;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace ProductCURD
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Product")]
    [Route("api/app/product")]
    public class ProductController:AbpController
    {
        private IProductAppService _productAppService;

        public ProductController(IProductAppService _productAppService)
        {
            _productAppService = IProductAppService;

        }

        [HttpGet]
        public virtual Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _productAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ProductDto> GetAsync(Guid id)
        {
            return _productAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            return _productAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ProductDto> UpdateAsync(int id, CreateUpdateProductDto input)
        {
            return _productAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _productAppService.DeleteAsync(id);
        }
    
}
}
*/
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductCURD.products;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace ProductCURD
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Products")]
    [Route("api/app/products")]
    public class ProductController : AbpController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<ProductDto>> GetListAsync([FromQuery] GetProductListDto input)
        {
            return await _productAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ProductDto> GetAsync(int id)
        {
            return await _productAppService.GetProductAsync(id);
        }

        [HttpPost]
        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            return await _productAppService.CreateProductAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ProductDto> UpdateAsync(int id, CreateUpdateProductDto input)
        {
            input.Id = id; 
            return await _productAppService.UpdateProductAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
          return  await _productAppService.DeleteProductAsync(id);
        }
    }
}
