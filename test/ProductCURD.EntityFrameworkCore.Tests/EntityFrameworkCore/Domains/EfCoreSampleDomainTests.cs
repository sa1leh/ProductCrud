using ProductCURD.Samples;
using Xunit;

namespace ProductCURD.EntityFrameworkCore.Domains;

[Collection(ProductCURDTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProductCURDEntityFrameworkCoreTestModule>
{

}
