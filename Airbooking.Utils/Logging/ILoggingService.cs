using System;

namespace Airbooking.Utils.Logging
{
    /// <summary>
    /// Logging Service Interface
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is information enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is information enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is trace enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is trace enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsTraceEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Debugs the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Debug(Exception exception);

        /// <summary>
        /// Debugs the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Debug(string format, params object[] args);

        /// <summary>
        /// Debugs the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Debug(Exception exception, string format, params object[] args);

        /// <summary>
        /// Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Error(Exception exception);

        /// <summary>
        /// Errors the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Error(string format, params object[] args);

        /// <summary>
        /// Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Error(Exception exception, string format, params object[] args);

        /// <summary>
        /// Fatals the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Fatal(Exception exception);

        /// <summary>
        /// Fatals the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Fatal(string format, params object[] args);

        /// <summary>
        /// Fatals the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Fatal(Exception exception, string format, params object[] args);

        /// <summary>
        /// Informations the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Info(Exception exception);

        /// <summary>
        /// Informations the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Info(string format, params object[] args);

        /// <summary>
        /// Informations the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Info(Exception exception, string format, params object[] args);

        /// <summary>
        /// Traces the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Trace(Exception exception);

        /// <summary>
        /// Traces the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Trace(string format, params object[] args);

        /// <summary>
        /// Traces the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Trace(Exception exception, string format, params object[] args);

        /// <summary>
        /// Warns the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Warn(Exception exception);

        /// <summary>
        /// Warns the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Warn(string format, params object[] args);

        /// <summary>
        /// Warns the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void Warn(Exception exception, string format, params object[] args);
    }
}
