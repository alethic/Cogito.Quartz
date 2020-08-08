namespace Cogito.Quartz.Options
{

    /// <summary>
    /// Configures the Quartz serializer.
    /// </summary>
    public class QuartzSerializerOptions
    {

        /// <summary>
        /// Describes the type of serialization to use.
        /// </summary>
        public string Type { get; set; } = QuartzSerializerType.Json;

    }

}