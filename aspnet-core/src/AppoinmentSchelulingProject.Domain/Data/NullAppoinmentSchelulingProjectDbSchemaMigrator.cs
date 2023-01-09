using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AppoinmentSchelulingProject.Data;

/* This is used if database provider does't define
 * IAppoinmentSchelulingProjectDbSchemaMigrator implementation.
 */
public class NullAppoinmentSchelulingProjectDbSchemaMigrator : IAppoinmentSchelulingProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
