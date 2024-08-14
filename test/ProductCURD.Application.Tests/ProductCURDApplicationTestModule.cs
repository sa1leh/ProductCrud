using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace ProductCURD;

[DependsOn(
    typeof(ProductCURDApplicationModule),
    typeof(ProductCURDDomainTestModule)
)]
public class ProductCURDApplicationTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default
     = "Server=(LocalDb)\\MSSQLLocalDB;Database=ProductCURD;Trusted_Connection=True;TrustServerCertificate=true";
        });
    }
}
