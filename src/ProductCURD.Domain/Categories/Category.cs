using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProductCURD.Categories
{
    public class Category:FullAuditedEntity<int>
    {
        public Category(int id, string categoryName) : base(id)
        {
           CategoryName = categoryName;
        }
        public string? CategoryName { get; set; }
    }
}
