using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Xunit;


namespace ProductCURD.products
{
    public class Integration : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public Integration(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Should_Create_A_New_Product()
        {
            // Arrange
            var newProduct = new ProductDto
            {
                Id = 135,
                ProductName = "For man",
                ProductDescription = "Cap",
                ProcudtPrice = 121,
                CategoryId = 1
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/app/products", newProduct);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdProduct = await response.Content.ReadFromJsonAsync<ProductDto>();
            createdProduct.Should().NotBeNull();
            createdProduct.Id.Should().Be(newProduct.Id);
            createdProduct.ProductName.Should().Be(newProduct.ProductName); 
            createdProduct.ProductDescription.Should().Be(newProduct.ProductDescription);
            createdProduct.ProcudtPrice.Should().Be(newProduct.ProcudtPrice);
            createdProduct.CategoryId.Should().Be(newProduct.CategoryId);
        }
        [Fact]
        public async Task Should_Get_Product_List()
        {
            // Act
            var response = await _client.GetAsync("api/app/products");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var productList = await response.Content.ReadFromJsonAsync<PagedResultDto<ProductDto>>();
            productList.Should().NotBeNull();
            productList.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Should_Get_Product_By_Id()
        {
            // Arrange
            int productId = 18267; 

            // Act
            var response = await _client.GetAsync($"api/app/products/{productId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var product = await response.Content.ReadFromJsonAsync<ProductDto>();
            product.Should().NotBeNull();
            product.Id.Should().Be(productId);
        }

        [Fact]
        public async Task Should_Update_Product()
        {
            // Arrange
            int productId = 10;
            var updatedProduct = new CreateUpdateProductDto
            {
                ProductName = "Updated Name",
                ProductDescription = "Updated Description",
                ProcudtPrice = 150,
                CategoryId = 1
            };

            // Act
            var response = await _client.PutAsJsonAsync($"api/app/products/{productId}", updatedProduct);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var product = await response.Content.ReadFromJsonAsync<ProductDto>();
            product.Should().NotBeNull();
            product.ProductName.Should().Be(updatedProduct.ProductName);
            product.ProductDescription.Should().Be(updatedProduct.ProductDescription);
            product.ProcudtPrice.Should().Be(updatedProduct.ProcudtPrice);
            product.CategoryId.Should().Be(updatedProduct.CategoryId);
        }

        [Fact]
        public async Task Should_Delete_Product()
        {
            // Arrange
            int productId = 135; 

            // Act
            var response = await _client.DeleteAsync($"api/app/products/{productId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
