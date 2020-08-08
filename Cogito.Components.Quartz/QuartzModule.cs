using Autofac;
using Autofac.Extras.Quartz;

using Cogito.Autofac;

namespace Cogito.Components.Quartz
{

    /// <summary>
    /// Describes types required for this service.
    /// </summary>
    public class QuartzModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(QuartzModule).Assembly);
            builder.RegisterModule(new QuartzAutofacFactoryModule() { ConfigurationProvider = ctx => ctx.Resolve<QuartzConfigurationProvider>().Build() });
        }

    }

}
