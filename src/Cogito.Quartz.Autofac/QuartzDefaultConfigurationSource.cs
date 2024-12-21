using System.Collections.Generic;

using Cogito.Autofac;

namespace Cogito.Quartz.Autofac
{

    /// <summary>
    /// Applies the default Quartz configuration.
    /// </summary>
    [RegisterAs(typeof(IQuartzConfigurationSource))]
    [RegisterOrder(int.MinValue)]
    public class QuartzDefaultConfigurationSource : IQuartzConfigurationSource
    {

        static readonly Dictionary<string, string> DEFAULT = new Dictionary<string, string>()
        {
            ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
            ["quartz.threadPool.threadCount"] = "5",
            ["quartz.threadPool.threadPriority"] = "Normal",
        };

        public IEnumerable<(string Key, string Value)> GetConfiguration()
        {
            foreach (var kvp in DEFAULT)
                yield return (kvp.Key, kvp.Value);
        }

    }

}
