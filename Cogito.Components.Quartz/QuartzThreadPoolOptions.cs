namespace Cogito.Components.Quartz
{

    public class QuartzThreadPoolOptions
    {

        /// <summary>
        /// Type of the thread pool.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Thread pool thread count.
        /// </summary>
        public int? ThreadCount { get; set; }

        /// <summary>
        /// Priority of the threads in the thread pool.
        /// </summary>
        public string ThreadPriority { get; set; }

    }

}
