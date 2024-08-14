using ProductCURD.Categories;
using Xunit;

namespace ProductCURD.EntityFrameworkCore.Applications.Categories;

[Collection(ProductCURDTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : CategoryAppServiceTests<ProductCURDEntityFrameworkCoreTestModule>
{

}


/*sing ProductCURD.Categories;
using Xunit;

namespace ProductCURD.EntityFrameworkCore.Applications.Categories
{
    [Collection(ProductCURDTestConsts.CollectionDefinitionName)]
    public class EfCoreBookAppService_Tests : CategoryAppServiceTests()
    {
        public EfCoreBookAppService_Tests() : base()
        {
        }

    }
}
*/