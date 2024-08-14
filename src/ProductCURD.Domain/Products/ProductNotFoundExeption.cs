using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ProductCURD.Products
{
    public class ProductNotFoundExeption :BusinessException
    {
        public ProductNotFoundExeption(int id) :base(ProductCURDDomainErrorCodes.Product_Not_Found_Exeption)
        {
            WithData("id", id);
        }
    }
}
