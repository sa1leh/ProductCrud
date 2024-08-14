using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProductCURD.Categories
{
    public class CreateUpdateDto:EntityDto<int>
    {
        
        public string? CategoryName { get; set; }
    }
}
