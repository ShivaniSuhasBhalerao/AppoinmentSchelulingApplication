using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AppoinmentSchelulingProject.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AppoinmentSchelulingProjectDbContextFactory : IDesignTimeDbContextFactory<AppoinmentSchelulingProjectDbContext>
{
    public AppoinmentSchelulingProjectDbContext CreateDbContext(string[] args)
    {
        AppoinmentSchelulingProjectEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AppoinmentSchelulingProjectDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AppoinmentSchelulingProjectDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AppoinmentSchelulingProject.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
