using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductCURD.Bases;
using ProductCURD.products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ProductCURD.Products
{
    public class ProductAppService : BasesAppService, IProductAppService
    {
        #region fields

        private readonly IRepository<Product, int> _productRepository;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public ProductAppService(IRepository<Product, int> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #endregion

        #region IProductAppService

        public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input)
        {            
            var product = _mapper.Map<CreateUpdateProductDto, Product>(input);
            var inserted = await _productRepository.InsertAsync(product, autoSave: true);
            return _mapper.Map<Product, ProductDto>(inserted);
        }
               
        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetAsync(id);
            if (existingProduct == null)
            {
                return false;
            }
            await _productRepository.DeleteAsync(id, autoSave: true); 
            return true;
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
        {
            if (string.IsNullOrEmpty(input.Sorting))
            {
                input.Sorting = nameof(Product.Id);
            }

            var query = _productRepository
                .WithDetailsAsync(product => product.Category)
                .Result
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(input.Filter))
            {
                query = query.Where(product => product.ProductName.Contains(input.Filter));
            }

            var totalCount = await query.CountAsync();
            var products = await query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var productDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);

            return new PagedResultDto<ProductDto>(totalCount, productDtos);
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var products = await _productRepository
                .WithDetailsAsync(c => c.Category)
                .Result
                .Include(c => c.Category) 
                .FirstOrDefaultAsync(x => x.Id == id);
          
            if (products == null)
            {
                throw new ProductNotFoundExeption(id);
            }

            return _mapper.Map<Product, ProductDto>(products);
        }
       
        public async Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input)
        {
            var existingProduct = await _productRepository.GetAsync(input.Id);
            if (existingProduct == null)
            {
                throw new ProductNotFoundExeption(input.Id);
            }

            var updatedProduct = _mapper.Map(input, existingProduct);
            await _productRepository.UpdateAsync(updatedProduct, autoSave: true);

            return _mapper.Map<Product, ProductDto>(updatedProduct);
        }


        #endregion
    }
}
