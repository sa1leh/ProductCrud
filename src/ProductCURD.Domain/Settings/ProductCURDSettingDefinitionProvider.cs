using Volo.Abp.Settings;

namespace ProductCURD.Settings;

public class ProductCURDSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProductCURDSettings.MySetting1));
    }
}
