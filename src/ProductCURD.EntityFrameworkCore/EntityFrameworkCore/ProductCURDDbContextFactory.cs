using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProductCURD.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ProductCURDDbContextFactory : IDesignTimeDbContextFactory<ProductCURDDbContext>
{
    public ProductCURDDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        ProductCURDEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ProductCURDDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new ProductCURDDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ProductCURD.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
