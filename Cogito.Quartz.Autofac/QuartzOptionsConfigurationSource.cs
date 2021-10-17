using System.Collections.Generic;

using Cogito.Autofac;
using Cogito.Quartz.Options;

using Microsoft.Extensions.Options;

using Quartz.Impl;

namespace Cogito.Quartz.Autofac
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
                if (!string.IsNullOrWhiteSpace(o.Scheduler?.InstanceName))
                    o.Settings[StdSchedulerFactory.PropertySchedulerInstanceName] = o.Scheduler?.InstanceName;
                if (!string.IsNullOrWhiteSpace(o.Scheduler?.InstanceId))
                    o.Settings[StdSchedulerFactory.PropertySchedulerInstanceId] = o.Scheduler?.InstanceId;
                if (!string.IsNullOrWhiteSpace(o.Scheduler?.JobFactory?.Type))
                    o.Settings[StdSchedulerFactory.PropertySchedulerJobFactoryType] = o.Scheduler?.JobFactory?.Type;

                if (!string.IsNullOrWhiteSpace(o.ThreadPool?.Type))
                    yield return (StdSchedulerFactory.PropertyThreadPoolType, o.ThreadPool?.Type);
                if (o.ThreadPool?.ThreadCount != null)
                    yield return ($"{StdSchedulerFactory.PropertyThreadPoolPrefix}.threadCount", o.ThreadPool?.ThreadCount.ToString());
                if (!string.IsNullOrWhiteSpace(o.ThreadPool?.ThreadPriority))
                    yield return ($"{StdSchedulerFactory.PropertyThreadPoolPrefix}.threadPriority", o.ThreadPool?.ThreadPriority);

                if (!string.IsNullOrWhiteSpace(o.DataSource?.Provider) ||
                    !string.IsNullOrWhiteSpace(o.DataSource?.ConnectionString))
                {
                    yield return ($"{StdSchedulerFactory.PropertyJobStorePrefix}.dataSource", "default");

                    if (!string.IsNullOrWhiteSpace(o.DataSource?.Provider))
                        yield return ($"{StdSchedulerFactory.PropertyDataSourcePrefix}.default.provider", o.DataSource?.Provider);
                    if (!string.IsNullOrWhiteSpace(o.DataSource?.ConnectionString))
                        yield return ($"{StdSchedulerFactory.PropertyDataSourcePrefix}.default.connectionString", o.DataSource?.ConnectionString);
                }

                if (!string.IsNullOrWhiteSpace(o.JobStore?.DriverDelegateType))
                    yield return ($"{StdSchedulerFactory.PropertyJobStorePrefix}.driverDelegateType", o.JobStore?.DriverDelegateType);
                if (!string.IsNullOrWhiteSpace(o.JobStore?.Type))
                    yield return ($"{StdSchedulerFactory.PropertyJobStorePrefix}.type", o.JobStore?.Type);
                if (!string.IsNullOrWhiteSpace(o.JobStore?.TablePrefix))
                    yield return ($"{StdSchedulerFactory.PropertyJobStorePrefix}.{StdSchedulerFactory.PropertyTablePrefix}", o.JobStore?.TablePrefix);
                if (o.JobStore?.IsClustered != null)
                    yield return ($"{StdSchedulerFactory.PropertyJobStorePrefix}.clustered", (bool)o.JobStore?.IsClustered ? "true" : "false");
                if (o.JobStore?.UseProperties != null)
                    yield return ($"{StdSchedulerFactory.PropertyJobStorePrefix}.useProperties", (bool)o.JobStore.UseProperties ? "true" : "false");

                if (o.Serializer?.Type != null)
                    yield return ($"{StdSchedulerFactory.PropertyObjectSerializer}.type", o.Serializer.Type);

                if (o.Settings != null)
                    foreach (var kvp in o.Settings)
                        yield return (kvp.Key, kvp.Value);
            }
        }

    }

}
