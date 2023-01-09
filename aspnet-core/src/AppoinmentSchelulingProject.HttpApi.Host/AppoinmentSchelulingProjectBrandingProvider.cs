using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AppoinmentSchelulingProject;

[Dependency(ReplaceServices = true)]
public class AppoinmentSchelulingProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AppoinmentSchelulingProject";
}
