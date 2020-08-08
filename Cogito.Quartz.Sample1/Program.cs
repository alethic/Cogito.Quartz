using Autofac.Extensions.DependencyInjection;

using Cogito.Autofac;
using Cogito.Extensions.Options;
using Cogito.Extensions.Options.Autofac;
using Cogito.Extensions.Options.Configuration.Autofac;
using Cogito.Quartz.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
