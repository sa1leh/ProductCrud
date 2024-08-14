using Volo.Abp.Modularity;

namespace ProductCURD;

/* Inherit from this class for your domain layer tests. */
public abstract class ProductCURDDomainTestBase<TStartupModule> : AbpIntegrationTest<TStartupModule>
    where TStartupModule : IAbpModule
{

}
