using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCURD.Data;
using Volo.Abp.DependencyInjection;

namespace ProductCURD.EntityFrameworkCore;

public class EntityFrameworkCoreProductCURDDbSchemaMigrator
    : IProductCURDDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProductCURDDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ProductCURDDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProductCURDDbContext>()
            .Database
            .MigrateAsync();
    }
}
