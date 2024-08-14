using Volo.Abp.Application.Dtos;

namespace ProductCURD.products
{
    public class ProductDto :FullAuditedEntityDto<int>
    {
       
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? ProcudtPrice { get; set; }

        public int? CategoryId { get; set; }

       public string? CategoryCategoryName { get; set; }
    }
}
