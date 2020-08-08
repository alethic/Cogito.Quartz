namespace Cogito.Components.Quartz
{

    public class QuartzJobStoreOptions
    {

        /// <summary>
        /// Drive delegate type.
        /// </summary>
        public string DriverDelegateType { get; set; }

        /// <summary>
        /// Job store type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// ADO.Net table prefix.
        /// </summary>
        public string TablePrefix { get; set; }

        /// <summary>
        /// Use properties setting.
        /// </summary>
        public bool? UseProperties { get; set; }

        /// <summary>
        /// Is the job store clustered?
        /// </summary>
        public bool? IsClustered { get; set; }

    }

}
