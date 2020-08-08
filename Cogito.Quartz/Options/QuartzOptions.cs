using System.Collections.Generic;

namespace Cogito.Quartz.Options
{

    public class QuartzOptions
    {

        /// <summary>
        /// Thread pool configuration.
        /// </summary>
        public QuartzThreadPoolOptions ThreadPool { get; set; } = new QuartzThreadPoolOptions();

        /// <summary>
        /// Data source configuration.
        /// </summary>
        public QuartzDataSourceOptions DataSource { get; set; } = new QuartzDataSourceOptions();

        /// <summary>
        /// Job store configuration.
        /// </summary>
        public QuartzJobStoreOptions JobStore { get; set; } = new QuartzJobStoreOptions();

        /// <summary>
        /// Serializer configuration.
        /// </summary>
        public QuartzSerializerOptions Serializer { get; set; } = new QuartzSerializerOptions();

        /// <summary>
        /// Additional Quartz settings.
        /// </summary>
        public IDictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();

    }

}
