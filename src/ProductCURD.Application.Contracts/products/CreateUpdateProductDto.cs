using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ProductCURD.products
{
    public class CreateUpdateProductDto:EntityDto<int>
    {

        [MaxLength(100)]
        [MinLength(1, ErrorMessage = "Product name cannot be empty.")]
        [Required]
        public string ProductName { get; set; }

        [MaxLength(1000)]
        public string? ProductDescription { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Product price must be a positive value.")]
        public decimal? ProcudtPrice { get; set; }

        [Required]
        public int? CategoryId { get; set; }

    }
}
