using Autofac.Extensions.DependencyInjection;
using Cogito.Extensions.Configuration.Autofac;

using Cogito.Autofac;
using Cogito.Extensions.Options.Configuration.Autofac;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Cogito.Extensions.Options.Autofac;

namespace Cogito.Components.Quartz.Sample1
{

    public static class Program
    {

        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(b => b
                    .Configure<QuartzOptions>(o => o.Settings.Add("Foo", "123"))
                    .RegisterAllAssemblyModules()))
                .ConfigureAppConfiguration(b => b.AddEnvironmentVariables())
                .Build()
                .RunAsync();
        }

    }

}
