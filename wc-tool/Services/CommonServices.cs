using Microsoft.Extensions.DependencyInjection;

using wc_tool.Processor;
using wc_tool.Sources;
using WcTool.Application;
using WcTool.Interfaces;
using WcTool.Sources;

namespace WcTool.Services
{
    public static class CommonServices
    {
        public static void  Register(IServiceCollection services, string[] args)
        {
            services.AddTransient<FileTextSource>();
            services.AddTransient<ConsoleTextSource>();
            services.AddTransient<IWcProcessor, WcProcessor>();
            services.AddTransient<CliApp>();
            services.AddLogging();

        }
    }
}
//C:\AKHIL\reference\test