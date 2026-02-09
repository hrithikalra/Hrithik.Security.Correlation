#nullable enable

using Microsoft.Extensions.Logging;
using Hrithik.Security.Correlation.Abstractions;
using System;

namespace Hrithik.Security.Correlation.Logging
{
    /// <summary>
    /// Extensions for enriching logs with correlation identifiers.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Begins a logging scope containing the correlation identifier.
        /// </summary>
        public static IDisposable? BeginCorrelationScope(
            this ILogger logger,
            ICorrelationContext context)
        {
            return logger.BeginScope(
                "CorrelationId: {CorrelationId}",
                context.CorrelationId);
        }
    }
}
