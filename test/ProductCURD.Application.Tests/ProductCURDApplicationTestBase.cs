using Volo.Abp.Modularity;

namespace ProductCURD;

public abstract class ProductCURDApplicationTestModule<TStartupModule> : AbpIntegrationTest<TStartupModule>
    where TStartupModule : IAbpModule
{

}
