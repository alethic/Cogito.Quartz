using System;

using Cogito.Autofac;

using Microsoft.Extensions.Logging;

using Quartz.Logging;

namespace Cogito.Components.Quartz
{

    /// <summary>
    /// Generates log instances for Quartz.
    /// </summary>
    [RegisterAs(typeof(ILogProvider))]
    public class QuartzLogAdapter : ILogProvider
    {

        /// <summary>
        /// Does nothing upon dispose.
        /// </summary>
        class NullDisposable : IDisposable
        {

            public void Dispose()
            {

            }

        }

        /// <summary>
        /// Logger instance generated for Quartz.
        /// </summary>
        class QuartzLogger
        {

            readonly ILogger logger;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="logger"></param>
            public QuartzLogger(ILogger logger)
            {
                this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            /// <summary>
            /// Implements the Quartz logging method.
            /// </summary>
            /// <param name="level"></param>
            /// <param name="message"></param>
            /// <param name="exception"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            public bool Log(global::Quartz.Logging.LogLevel level, Func<string> message, Exception exception, object[] args)
            {
                switch (level)
                {
                    case global::Quartz.Logging.LogLevel.Trace:
                        if (logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
                        {
                            if (exception != null)
                                logger.LogTrace(exception, message?.Invoke(), args);
                            else
                                logger.LogTrace(message?.Invoke(), args);

                            return true;
                        }

                        return false;
                    case global::Quartz.Logging.LogLevel.Debug:
                        if (logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug))
                        {
                            if (exception != null)
                                logger.LogDebug(exception, message?.Invoke(), args);
                            else
                                logger.LogDebug(message?.Invoke(), args);

                            return true;
                        }

                        return false;
                    case global::Quartz.Logging.LogLevel.Info:
                        if (logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Information))
                        {
                            if (exception != null)
                                logger.LogInformation(exception, message?.Invoke(), args);
                            else
                                logger.LogInformation(message?.Invoke(), args);

                            return true;
                        }

                        return false;
                    case global::Quartz.Logging.LogLevel.Warn:
                        if (logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Warning))
                        {
                            if (exception != null)
                                logger.LogWarning(exception, message?.Invoke(), args);
                            else
                                logger.LogWarning(message?.Invoke(), args);

                            return true;
                        }

                        return false;
                    case global::Quartz.Logging.LogLevel.Error:
                    case global::Quartz.Logging.LogLevel.Fatal:
                        if (logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Error))
                        {
                            if (exception != null)
                                logger.LogError(exception, message?.Invoke(), args);
                            else
                                logger.LogError(message?.Invoke(), args);

                            return true;
                        }

                        return false;
                }

                return false;
            }

        }

        readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="logger"></param>
        public QuartzLogAdapter(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Returns a logging function for quartz.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Logger GetLogger(string name)
        {
            return new QuartzLogger(logger).Log;
        }

        public IDisposable OpenNestedContext(string message)
        {
            return new NullDisposable();
        }

        public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
        {
            return new NullDisposable();
        }

    }

}
