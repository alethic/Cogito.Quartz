using System.Collections.Generic;

namespace Cogito.Quartz.Autofac
{

    /// <summary>
    /// Provides configuration data for the Quartz scheduler.
    /// </summary>
    public interface IQuartzConfigurationSource
    {

        /// <summary>
        /// Provides configuration data for the Quartz scheduler.
        /// </summary>
        /// <returns></returns>
        IEnumerable<(string Key, string Value)> GetConfiguration();

    }

}
