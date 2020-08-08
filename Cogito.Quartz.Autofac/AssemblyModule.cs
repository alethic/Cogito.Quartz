using Autofac;
using Autofac.Extras.Quartz;

using Cogito.Autofac;
using Cogito.Extensions.Options.Configuration.Autofac;
using Cogito.Quartz.Hosting;
using Cogito.Quartz.Options;

using Microsoft.Extensions.Hosting;

namespace Cogito.Quartz.Autofac
{

    /// <summary>
    /// Describes types required for this service.
    /// </summary>
    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.RegisterModule(new QuartzAutofacFactoryModule() { ConfigurationProvider = ctx => ctx.Resolve<QuartzConfigurationProvider>().Build() });
            builder.Configure<QuartzOptions>("Quartz");
            builder.Configure<QuartzHostedServiceOptions>("Quartz:Host");
            builder.RegisterType<QuartzHostedService>().As<IHostedService>();
        }

    }

}
