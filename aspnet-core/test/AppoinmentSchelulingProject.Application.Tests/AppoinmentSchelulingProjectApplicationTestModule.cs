using Volo.Abp.Modularity;

namespace AppoinmentSchelulingProject;

[DependsOn(
    typeof(AppoinmentSchelulingProjectApplicationModule),
    typeof(AppoinmentSchelulingProjectDomainTestModule)
    )]
public class AppoinmentSchelulingProjectApplicationTestModule : AbpModule
{

}
