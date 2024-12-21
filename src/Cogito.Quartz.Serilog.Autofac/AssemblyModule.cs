using Autofac;

using Cogito.Autofac;

using FileAndServe.Components.Quartz.Logging;

using Serilog.Core;

namespace Cogito.Quartz.Serilog.Autofac
{

    /// <summary>
    /// Describes types required for this service.
    /// </summary>
    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.RegisterType<JobDetailDestructuringPolicy>().As<IDestructuringPolicy>();
            builder.RegisterType<TriggerDestructuringPolicy>().As<IDestructuringPolicy>();
        }

    }

}
