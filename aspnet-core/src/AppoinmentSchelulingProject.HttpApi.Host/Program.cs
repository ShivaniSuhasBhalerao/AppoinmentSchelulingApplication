using System;
using System.Threading.Tasks;
using AppoinmentSchelulingProject.Customers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace AppoinmentSchelulingProject;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
            Log.Information("Starting AppoinmentSchelulingProject.HttpApi.Host.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ITwilioSmsSender, TwilioSmsSender>();
            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<AppoinmentSchelulingProjectHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            //using (var scope = app.Services.CreateScope())
            //{
            //    var smssender = scope.ServiceProvider.GetRequiredService<ITwilioSmsSender>();

            //    await smssender.AutoDeleteAsync();

            //}

            using (var scope = app.Services.CreateScope())
            {
                var smssender = scope.ServiceProvider.GetRequiredService<ITwilioSmsSender>();

                smssender.StartTimerAsync();
            }
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
      
