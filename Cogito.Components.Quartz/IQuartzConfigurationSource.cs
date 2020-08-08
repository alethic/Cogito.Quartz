using System.Collections.Generic;

namespace Cogito.Components.Quartz
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
