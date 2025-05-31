using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcTool.Services;

namespace WcTool.Configurator
{
    public static class ServicesConfigurator
    {
        public static void Configure(HostBuilderContext context, IServiceCollection services, string[] args)
        {
            CommonServices.Register(services,args);

            if (context.HostingEnvironment.IsDevelopment())
            {
                //DevServices.Register(services);
            }
            else if (context.HostingEnvironment.IsProduction())
            {
                //ProdServices.Register(services);
            }
        }
    }
}
