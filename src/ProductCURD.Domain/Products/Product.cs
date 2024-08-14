using ProductCURD.Categories;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProductCURD.Products
{
    public class Product :FullAuditedEntity<int>
    {
        
        public int Id { get; set; }
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }
                
        public decimal? ProcudtPrice { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
