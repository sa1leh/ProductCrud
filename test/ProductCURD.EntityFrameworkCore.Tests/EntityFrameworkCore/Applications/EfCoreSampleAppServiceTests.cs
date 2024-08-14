using ProductCURD.Samples;
using Xunit;

namespace ProductCURD.EntityFrameworkCore.Applications;

[Collection(ProductCURDTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProductCURDEntityFrameworkCoreTestModule>
{

}
