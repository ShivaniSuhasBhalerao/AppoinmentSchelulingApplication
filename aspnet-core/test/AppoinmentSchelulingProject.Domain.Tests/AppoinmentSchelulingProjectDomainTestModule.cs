using AppoinmentSchelulingProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AppoinmentSchelulingProject;

[DependsOn(
    typeof(AppoinmentSchelulingProjectEntityFrameworkCoreTestModule)
    )]
public class AppoinmentSchelulingProjectDomainTestModule : AbpModule
{

}
