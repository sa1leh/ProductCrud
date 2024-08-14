using ProductCURD.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ProductCURD.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProductCURDEntityFrameworkCoreModule),
    typeof(ProductCURDApplicationContractsModule)
)]
public class ProductCURDDbMigratorModule : AbpModule
{
}
