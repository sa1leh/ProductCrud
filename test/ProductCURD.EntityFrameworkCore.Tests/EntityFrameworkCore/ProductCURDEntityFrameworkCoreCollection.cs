using Xunit;

namespace ProductCURD.EntityFrameworkCore;

[CollectionDefinition(ProductCURDTestConsts.CollectionDefinitionName)]
public class ProductCURDEntityFrameworkCoreCollection : ICollectionFixture<ProductCURDEntityFrameworkCoreFixture>
{

}
