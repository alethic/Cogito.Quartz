﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.Quartz;

using Cogito.Autofac;
using Cogito.Autofac.DependencyInjection;
using Cogito.Extensions.Options.Autofac;
using Cogito.Extensions.Options.Configuration.Autofac;

using Microsoft.Extensions.Logging;

using Quartz;
using Quartz.Logging;

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
            builder.Configure<QuartzOptions>("Quartz");
            builder.Configure<QuartzHostedServiceOptions>("Quartz:Host"); 
            builder.Populate(s => s.AddQuartz().AddQuartzHostedService());
            builder.RegisterBuildCallback(ctx => LogContext.SetCurrentLogProvider(ctx.Resolve<ILoggerFactory>()));
        }

    }

}
