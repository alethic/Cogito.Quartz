using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using Cogito.Autofac;
using Cogito.Collections;

using Microsoft.Extensions.Logging;

namespace Cogito.Quartz.Autofac
{

    [RegisterAs(typeof(QuartzConfigurationProvider))]
    class QuartzConfigurationProvider
    {

        readonly ILogger logger;
        readonly IEnumerable<IQuartzConfigurationSource> sources;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="sources"></param>
        public QuartzConfigurationProvider(IOrderedEnumerable<IQuartzConfigurationSource> sources, ILogger logger)
        {
            this.sources = sources ?? throw new ArgumentNullException(nameof(sources));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Compiles the configuration into a dictionary.
        /// </summary>
        /// <returns></returns>
        public NameValueCollection Build()
        {
            // default settings
            var c = new Dictionary<string, string>();

            // apply configuration from sources
            foreach (var source in sources)
                foreach (var kvp in source.GetConfiguration())
                    c[kvp.Key] = kvp.Value;

            // log for the user
            logger.LogInformation("Providing Quartz configuration: {Configuration}", c);

            // caller expects NVC
            return c.ToNameValueCollection();
        }

    }

}
