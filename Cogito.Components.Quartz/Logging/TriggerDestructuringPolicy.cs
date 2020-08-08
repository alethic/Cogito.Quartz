//using Quartz;

//namespace FileAndServe.Components.Quartz.Logging
//{

//    [RegisterAs(typeof(IDestructuringPolicy))]
//    public class TriggerDestructuringPolicy : IDestructuringPolicy
//    {

//        public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
//        {
//            if (value is ITrigger trigger)
//            {
//                result = propertyValueFactory.CreatePropertyValue(new
//                {
//                    trigger.CalendarName,
//                    trigger.Description,
//                    trigger.EndTimeUtc,
//                    trigger.FinalFireTimeUtc,
//                    trigger.HasMillisecondPrecision,
//                    JobDataMap = trigger.JobDataMap.WrappedMap,
//                    trigger.JobKey,
//                    trigger.Key,
//                    trigger.MisfireInstruction,
//                    trigger.Priority,
//                    trigger.StartTimeUtc
//                }, true);
//                return true;
//            }

//            result = null;
//            return false;
//        }

//    }

//}
