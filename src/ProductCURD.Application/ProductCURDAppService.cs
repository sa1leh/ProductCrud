using ProductCURD.Localization;
using Volo.Abp.Application.Services;

namespace ProductCURD;

/* Inherit your application services from this class.
 */
public abstract class ProductCURDAppService : ApplicationService
{
    protected ProductCURDAppService()
    {
        LocalizationResource = typeof(ProductCURDResource);
    }
}
