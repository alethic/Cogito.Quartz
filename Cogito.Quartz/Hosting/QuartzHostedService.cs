using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using Quartz;

namespace Cogito.Quartz.Hosting
{

    /// <summary>
    /// Provides a <see cref="IHostedService"/> implementation that starts the Quartz scheduler.
    /// </summary>
    public class QuartzHostedService : IHostedService
    {

        readonly IOptions<QuartzHostedServiceOptions> options;
        readonly IScheduler scheduler;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scheduler"></param>
        /// <param name="options"></param>
        public QuartzHostedService(IScheduler scheduler, IOptions<QuartzHostedServiceOptions> options)
        {
            this.scheduler = scheduler ?? throw new ArgumentNullException(nameof(scheduler));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await scheduler.Start(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return scheduler.Shutdown(options.Value.WaitForJobsToComplete, cancellationToken);
        }

    }
}
