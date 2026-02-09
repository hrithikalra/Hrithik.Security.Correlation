using System;

namespace Hrithik.Security.Correlation.Core
{
    /// <summary>
    /// Generates correlation identifiers.
    /// </summary>
    internal static class CorrelationIdGenerator
    {
        /// <summary>
        /// Generates a new correlation identifier.
        /// </summary>
        /// <returns>A unique correlation identifier.</returns>
        public static string Generate()
            => Guid.NewGuid().ToString("N");
    }
}
