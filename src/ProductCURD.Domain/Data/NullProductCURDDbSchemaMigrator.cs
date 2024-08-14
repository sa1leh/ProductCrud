using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ProductCURD.Data;

/* This is used if database provider does't define
 * IProductCURDDbSchemaMigrator implementation.
 */
public class NullProductCURDDbSchemaMigrator : IProductCURDDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
