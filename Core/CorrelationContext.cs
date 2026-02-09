using System.Threading;
using Hrithik.Security.Correlation.Abstractions;

namespace Hrithik.Security.Correlation.Core
{
    /// <summary>
    /// Default implementation of <see cref="ICorrelationContext"/> using AsyncLocal storage.
    /// </summary>
    internal sealed class CorrelationContext : ICorrelationContext
    {
        private static readonly AsyncLocal<string?> _correlationId = new();

        /// <inheritdoc />
        public string CorrelationId
            => _correlationId.Value ?? string.Empty;

        /// <summary>
        /// Sets the correlation identifier for the current async flow.
        /// </summary>
        /// <param name="correlationId">Correlation identifier to set.</param>
        internal static void Set(string correlationId)
        {
            _correlationId.Value = correlationId;
        }
    }
}
