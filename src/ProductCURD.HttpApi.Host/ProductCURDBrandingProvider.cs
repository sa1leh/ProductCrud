using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProductCURD;

[Dependency(ReplaceServices = true)]
public class ProductCURDBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ProductCURD";
}
