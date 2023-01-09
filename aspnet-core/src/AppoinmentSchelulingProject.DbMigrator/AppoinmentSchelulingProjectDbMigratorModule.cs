using AppoinmentSchelulingProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AppoinmentSchelulingProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AppoinmentSchelulingProjectEntityFrameworkCoreModule),
    typeof(AppoinmentSchelulingProjectApplicationContractsModule)
)]
public class AppoinmentSchelulingProjectDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });
    }
}
