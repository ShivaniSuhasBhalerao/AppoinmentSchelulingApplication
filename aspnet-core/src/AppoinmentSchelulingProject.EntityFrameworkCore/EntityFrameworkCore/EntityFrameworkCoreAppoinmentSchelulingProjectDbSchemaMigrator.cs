using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppoinmentSchelulingProject.Data;
using Volo.Abp.DependencyInjection;

namespace AppoinmentSchelulingProject.EntityFrameworkCore;

public class EntityFrameworkCoreAppoinmentSchelulingProjectDbSchemaMigrator
    : IAppoinmentSchelulingProjectDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAppoinmentSchelulingProjectDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AppoinmentSchelulingProjectDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AppoinmentSchelulingProjectDbContext>()
            .Database
            .MigrateAsync();
    }
}
