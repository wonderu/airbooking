using NLog;
using System;

namespace Airbooking.Utils.Logging
{
    /// <summary>
    /// Logging Service Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Airbooking.Utils.Logging.ILoggingService" />
    public class LoggingService<T> : ILoggingService
    {
        /// <summary>
        /// The _logger name
        /// </summary>
        private readonly string _loggerName;
        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger;

        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorEnabled => _logger.IsErrorEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is information enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is information enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsInfoEnabled => _logger.IsInfoEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is trace enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is trace enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsTraceEnabled => _logger.IsTraceEnabled;

        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarnEnabled => _logger.IsWarnEnabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingService{T}"/> class.
        /// </summary>
        public LoggingService()
        {
            _loggerName = typeof(T).ToString();
            _logger =LogManager.GetLogger(_loggerName, typeof(T));
        }

        //public static ILoggingService GetLoggingService()
        //{
        //    //ConfigurationItemFactory.Default.LayoutRenderers
        //    //    .RegisterDefinition("utc_date", typeof(UtcDateRenderer));
        //    //ConfigurationItemFactory.Default.LayoutRenderers
        //    //    .RegisterDefinition("web_variables", typeof(WebVariablesRenderer));

        //    return logger;
        //}

        /// <summary>
        /// Debugs the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Debug(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsDebugEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Debug, exception, format.AddRequestId(), args);
            _logger.Log(typeof(T), logEvent);
        }

        /// <summary>
        /// Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Error(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsErrorEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Error, exception, format, args);
            _logger.Log(typeof(T), logEvent);
        }

        /// <summary>
        /// Fatals the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Fatal, exception, format.AddRequestId(), args);
            _logger.Log(typeof(T), logEvent);
        }

        /// <summary>
        /// Informations the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Info(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsInfoEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Info, exception, format.AddRequestId(), args);
            _logger.Log(typeof(T), logEvent);
        }

        /// <summary>
        /// Traces the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Trace(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsTraceEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Trace, exception, format.AddRequestId(), args);
            _logger.Log(typeof(T), logEvent);
        }

        /// <summary>
        /// Warns the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Warn(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsWarnEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Warn, exception, format.AddRequestId(), args);
            _logger.Log(typeof(T), logEvent);
        }

        /// <summary>
        /// Debugs the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Debug(Exception exception)
        {
            Debug(exception, string.Empty);
        }

        /// <summary>
        /// Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Error(Exception exception)
        {
            Error(exception, string.Empty);
        }

        /// <summary>
        /// Fatals the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Fatal(Exception exception)
        {
            Fatal(exception, string.Empty);
        }

        /// <summary>
        /// Informations the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Info(Exception exception)
        {
            Info(exception, string.Empty);
        }

        /// <summary>
        /// Traces the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Trace(Exception exception)
        {
            Trace(exception, string.Empty);
        }

        /// <summary>
        /// Warns the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Warn(Exception exception)
        {
            Warn(exception, string.Empty);
        }

        /// <summary>
        /// Gets the log event.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <param name="level">The level.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        private LogEventInfo GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            string assemblyProp = string.Empty;
            string classProp = string.Empty;
            string methodProp = string.Empty;
            string messageProp = string.Empty;
            string innerMessageProp = string.Empty;

            var logEvent = new LogEventInfo
                (level, loggerName, string.Format(format, args));

            if (exception != null)
            {
                assemblyProp = exception.Source;
                if (exception.TargetSite.DeclaringType != null)
                    classProp = exception.TargetSite.DeclaringType.FullName;
                methodProp = exception.TargetSite.Name;
                messageProp = exception.Message;

                if (exception.InnerException != null)
                {
                    innerMessageProp = exception.InnerException.Message;
                }
            }

            logEvent.Properties["error-source"] = assemblyProp;
            logEvent.Properties["error-class"] = classProp;
            logEvent.Properties["error-method"] = methodProp;
            logEvent.Properties["error-message"] = messageProp;
            logEvent.Properties["inner-error-message"] = innerMessageProp;

            return logEvent;
        }

        /// <summary>
        /// Debugs the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Debug(string format, params object[] args)
        {
            _logger.Debug(format.AddRequestId(), args);
        }

        /// <summary>
        /// Errors the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Error(string format, params object[] args)
        {
            _logger.Error(format.AddRequestId(), args);
        }

        /// <summary>
        /// Fatals the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Fatal(string format, params object[] args)
        {
            _logger.Fatal(format.AddRequestId(), args);
        }

        /// <summary>
        /// Informations the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Info(string format, params object[] args)
        {
            _logger.Info(format.AddRequestId(), args);
        }

        /// <summary>
        /// Traces the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Trace(string format, params object[] args)
        {
            _logger.Trace(format.AddRequestId(), args);
        }

        /// <summary>
        /// Warns the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Warn(string format, params object[] args)
        {
            _logger.Warn(format.AddRequestId(), args);
        }
    }
}
