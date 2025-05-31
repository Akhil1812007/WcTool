using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WcTool.Application;
using WcTool.Configurator;

namespace WcTool
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    ServicesConfigurator.Configure(context, services,args);
                })
                .Build();
            var app = host.Services.GetRequiredService<CliApp>();
            await app.RunAsync(args);
        }
    }
}
/*
 *     .ConfigureServices((hostContext, services) =>
    {
        // Use hostContext for environment/config info
        // Register services on 'services'

        if (hostContext.HostingEnvironment.IsDevelopment())
        {
            // Register dev-only services
        }

        services.AddSingleton<IMyService, MyServiceImplementation>();
    })
 */