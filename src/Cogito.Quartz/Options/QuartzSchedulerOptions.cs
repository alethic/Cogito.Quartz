namespace Cogito.Quartz.Options
{

    public class QuartzSchedulerOptions
    {

        /// <summary>
        /// Name of the instance.
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// ID of the instance.
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// Options for the job factory.
        /// </summary>
        public QuartzSchedulerJobFactoryOptions JobFactory { get; set; } = new QuartzSchedulerJobFactoryOptions();

    }

}
