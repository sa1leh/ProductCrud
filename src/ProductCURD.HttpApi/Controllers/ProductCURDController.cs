using ProductCURD.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ProductCURD.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProductCURDController : AbpControllerBase
{
    protected ProductCURDController()
    {
        LocalizationResource = typeof(ProductCURDResource);
    }
}
