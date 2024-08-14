using AutoMapper;
using MockQueryable.Moq;
using Moq;
using NSubstitute;
using ProductCURD.Mapping;
using ProductCURD.Products;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace ProductCURD.products
{
    public class ProductAppServiceTests
    {   
        private readonly IProductAppService _productAppService;
        private readonly IRepository<Product, int> _productRepository;
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Product, int>> _productRepositoryMock;

        public ProductAppServiceTests()
        {
            _productRepository = Substitute.For<IRepository<Product, int>>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductMapping>());
            _mapper = config.CreateMapper();

            _productRepositoryMock = new Mock<IRepository<Product, int>>();
            _productAppService = new ProductAppService(_productRepository, _mapper);
           
        }

        [Fact]
        public async Task Should_Create_A_New_Product()
        {
            // Arrange
            var newProductDto = new CreateUpdateProductDto
            {
                ProductName = "Test Product",
                ProductDescription = "Product Description",
                ProcudtPrice = 19.99m,
                Id = 1
            };
            var createdProduct = new Product
            {
                ProductName = "Test Product",
                ProductDescription = "Product Description",
                ProcudtPrice = 19.99m,
                Id = 1
            };

            _productRepository.InsertAsync(Arg.Any<Product>(), true)
                .Returns(Task.FromResult(createdProduct));

            // Act
            var result = await _productAppService.CreateProductAsync(newProductDto);

            // Assert
            result.ShouldNotBeNull();
            result.ProductName.ShouldBe("Test Product");
            result.ProcudtPrice.ShouldBe(19.99m);

            await _productRepository.Received().InsertAsync(
                Arg.Is<Product>(p => p.ProductName == "Test Product" && p.ProcudtPrice == 19.99m), true);
        }

        [Fact]
        public async Task Should_Update_An_Existing_Product()
        {
            // Arrange
            var existingProduct = new Product
            {
                ProductName = "Test Product",
                ProductDescription = "Product Description",
                ProcudtPrice = 19.99m,
                Id = 1
            };
            var updatedProductDto = new CreateUpdateProductDto
            {
                ProductName = "Updated Product",
                ProductDescription = "Updated Description",
                ProcudtPrice = 29.99m,
                Id = 2
            };

            _productRepository.GetAsync(2).Returns(Task.FromResult(existingProduct));
            _productRepository.UpdateAsync(Arg.Any<Product>(), true)
                .Returns(Task.FromResult(new Product { Id = 2, ProductName = updatedProductDto.ProductName, ProcudtPrice = updatedProductDto.ProcudtPrice }));

            // Act
            var result = await _productAppService.UpdateProductAsync(updatedProductDto);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(2);
            result.ProductName.ShouldBe(updatedProductDto.ProductName);
            result.ProcudtPrice.ShouldBe(updatedProductDto.ProcudtPrice);

            await _productRepository.Received().UpdateAsync(
                Arg.Is<Product>(p => p.Id == 2 && p.ProductName == updatedProductDto.ProductName && p.ProcudtPrice == updatedProductDto.ProcudtPrice), true);
        }
      
        [Fact]
        public async Task Should_Delete_Product_By_Id()
        {
            // Arrange
            var productIdToDelete = 1;
            var existingProduct = new Product { Id = productIdToDelete };
            _productRepository.GetAsync(productIdToDelete).Returns(existingProduct);

            // Act
            var result = await _productAppService.DeleteProductAsync(productIdToDelete);

            // Assert
            Assert.True(result); 
            await _productRepository.Received().DeleteAsync(productIdToDelete, Arg.Any<bool>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Should_Get_Product_By_Id_Successfully()
        {
            // Arrange
            var existingProductId = 1;

            var product = new Product
            {
                Id = existingProductId,
                ProductName = "Test Product",
                ProcudtPrice = 100,
            };

            var products = new List<Product> { product };

            var mockDbSet = products.AsQueryable().BuildMockDbSet();

            _productRepository.WithDetailsAsync(Arg.Any<Expression<Func<Product, object>>>())
                .Returns(Task.FromResult(mockDbSet.Object.Where(p => p.Id == existingProductId).AsQueryable()));

            // Act
            var result = await _productAppService.GetProductAsync(existingProductId);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(existingProductId);
            result.ProductName.ShouldBe("Test Product");
            result.ProcudtPrice.ShouldBe(100);
        }
        [Fact]
        public async Task Should_Get_All_Product()
        {
            // Arrange
            var products = new List<Product>
    {
        new Product { Id = 1, ProductName = "Test Product 1", ProcudtPrice = 100 },
        new Product { Id = 2, ProductName = "Test Product 2", ProcudtPrice = 200 },
    };

            var mockDbSet = products.AsQueryable().BuildMockDbSet();

            _productRepository.WithDetailsAsync(Arg.Any<Expression<Func<Product, object>>>())
                .Returns(Task.FromResult(mockDbSet.Object.AsQueryable()));

            var getProductListDto = new GetProductListDto
            {
                MaxResultCount = int.MaxValue,
                SkipCount = 0
            };

            // Act
            var result = await _productAppService.GetListAsync(getProductListDto);

            // Assert
            result.ShouldNotBeNull();
            result.TotalCount.ShouldBe(2);
            result.Items.First().Id.ShouldBe(1);
            result.Items.First().ProductName.ShouldBe("Test Product 1");
            result.Items.First().ProcudtPrice.ShouldBe(100);
            result.Items.Last().Id.ShouldBe(2);
            result.Items.Last().ProductName.ShouldBe("Test Product 2");
            result.Items.Last().ProcudtPrice.ShouldBe(200);
        }






    }
}