using System.Threading.Tasks;

namespace ProductCURD.Data;

public interface IProductCURDDbSchemaMigrator
{
    Task MigrateAsync();
}
