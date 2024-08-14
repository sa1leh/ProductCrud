using Volo.Abp.Modularity;

namespace ProductCURD;

[DependsOn(
    typeof(ProductCURDDomainModule),
    typeof(ProductCURDTestBaseModule)
)]
public class ProductCURDDomainTestModule : AbpModule
{

}
