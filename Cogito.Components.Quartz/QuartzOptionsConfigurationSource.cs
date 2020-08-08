using System.Collections.Generic;

using Cogito.Autofac;

using Microsoft.Extensions.Options;

namespace Cogito.Components.Quartz
{

    /// <summary>
    /// Provides configuration from the registered configuration object.
    /// </summary>
    [RegisterAs(typeof(IQuartzConfigurationSource))]
    [RegisterOrder(-1)]
    public class QuartzOptionsConfigurationSource : IQuartzConfigurationSource
    {

        readonly IOptions<QuartzOptions> options;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        public QuartzOptionsConfigurationSource(IOptions<QuartzOptions> options = null)
        {
            this.options = options;
        }

        public IEnumerable<(string Key, string Value)> GetConfiguration()
        {
            if (options != null && options.Value is QuartzOptions o)
            {
                if (!string.IsNullOrWhiteSpace(o.ThreadPool?.Type))
                    yield return ("quartz.threadPool.type", o.ThreadPool?.Type);
                if (o.ThreadPool?.ThreadCount != null)
                    yield return ("quartz.threadPool.threadCount", o.ThreadPool?.ThreadCount.ToString());
                if (!string.IsNullOrWhiteSpace(o.ThreadPool?.ThreadPriority))
                    yield return ("quartz.threadPool.threadPriority", o.ThreadPool?.ThreadPriority);
                if (!string.IsNullOrWhiteSpace(o.DataSource?.Provider))
                    yield return ("quartz.dataSource.default.provider", o.DataSource?.Provider);
                if (!string.IsNullOrWhiteSpace(o.DataSource?.ConnectionString))
                    yield return ("quartz.dataSource.default.connectionString", o.DataSource?.ConnectionString);
                if (!string.IsNullOrWhiteSpace(o.JobStore?.DriverDelegateType))
                    yield return ("quartz.jobStore.driverDelegateType", o.JobStore?.DriverDelegateType);
                if (!string.IsNullOrWhiteSpace(o.JobStore?.Type))
                    yield return ("quartz.jobStore.type", o.JobStore?.Type);
                if (!string.IsNullOrWhiteSpace(o.JobStore?.TablePrefix))
                    yield return ("quartz.jobStore.tablePrefix", o.JobStore?.TablePrefix);
                if (o.JobStore?.IsClustered != null)
                    yield return ("quartz.jobStore.clustered", (bool)o.JobStore?.IsClustered ? "true" : "false");
                if (o.JobStore?.UseProperties != null)
                    yield return ("quartz.jobStore.useProperties", (bool)o.JobStore.UseProperties ? "true" : "false");
                if (o.Serializer?.Type != null)
                    yield return ("quartz.serializer.type", o.Serializer.Type);

                if (o.Settings != null)
                    foreach (var kvp in o.Settings)
                        yield return (kvp.Key, kvp.Value);
            }
        }

    }

}
