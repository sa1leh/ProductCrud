using AutoMapper;
using Moq;
using NSubstitute;
using ProductCURD.Mapping;
using ProductCURD.products;
using Volo.Abp.Domain.Repositories;

namespace ProductCURD.Products.Tests
{

    [TestClass()]
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
        [TestMethod()]
        public void ProductAppServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateProductAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteProductAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetProductAsyncTestAsync()
        {
            // Arrange
            var product = new Product
            {
                ProductName = "Test Product",
                ProductDescription = "Product Description",
                ProcudtPrice = 19.99m,
                Id = 1
            };

            _productRepository.GetAsync(1).Returns(Task.FromResult(product));

            // Act
            var result =  _productAppService.GetProductAsync(1);

            // Assert
            /*result.ShouldNotBeNull();*/
            result.Id.ShouldBe(1);
            result.ProductName.ShouldBe("Test Product");
            result.ProcudtPrice.ShouldBe(19.99m);
        }
    

    [TestMethod()]
        public void UpdateProductAsyncTest()
        {
            Assert.Fail();
        }
    }
}