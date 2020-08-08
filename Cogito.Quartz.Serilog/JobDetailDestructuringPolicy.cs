using Quartz;

using Serilog.Core;
using Serilog.Events;

namespace FileAndServe.Components.Quartz.Logging
{

    public class JobDetailDestructuringPolicy : IDestructuringPolicy
    {

        public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
        {
            if (value is IJobDetail job)
            {
                result = propertyValueFactory.CreatePropertyValue(new
                {
                    job.Description,
                    job.Durable,
                    JobDataMap = job.JobDataMap.WrappedMap,
                    job.JobType,
                    job.Key,
                    job.PersistJobDataAfterExecution,
                    job.RequestsRecovery,

                }, true);
                return true;
            }

            result = null;
            return false;
        }

    }

}
