using System;
using System.Threading;
using System.Threading.Tasks;

using Cogito.Autofac;

using Microsoft.Extensions.Hosting;

using Quartz;

namespace Cogito.Components.Quartz
{

    /// <summary>
    /// Keeps the scheduler running.
    /// </summary>
    [RegisterAs(typeof(IHostedService))]
    public class QuartzHost : IHostedService
    {

        readonly IScheduler scheduler;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scheduler"></param>
        public QuartzHost(IScheduler scheduler)
        {
            this.scheduler = scheduler ?? throw new ArgumentNullException(nameof(scheduler));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (scheduler.IsStarted == false)
                await scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (scheduler.IsStarted)
                await scheduler.Shutdown(cancellationToken);
        }

    }

}
