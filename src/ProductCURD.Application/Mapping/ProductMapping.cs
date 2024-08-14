using AutoMapper;
using ProductCURD.products;
using ProductCURD.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCURD.Mapping
{
    public class ProductMapping :Profile
    {
       public ProductMapping() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateUpdateProductDto, Product>();
            
        }
    }
}
