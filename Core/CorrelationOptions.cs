namespace Hrithik.Security.Correlation.Core
{
    /// <summary>
    /// Configuration options for correlation handling.
    /// </summary>
    public sealed class CorrelationOptions
    {
        /// <summary>
        /// Gets or sets the HTTP header name used for correlation.
        /// Default is <c>X-Correlation-Id</c>.
        /// </summary>
        public string HeaderName { get; set; } = "X-Correlation-Id";

        /// <summary>
        /// Gets or sets a value indicating whether a correlation ID
        /// should be generated if missing.
        /// </summary>
        public bool GenerateIfMissing { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether strict validation
        /// should be enforced.
        /// </summary>
        public bool StrictValidation { get; set; } = false;

        /// <summary>
        /// Gets or sets the maximum allowed length of the correlation ID.
        /// </summary>
        public int MaxLength { get; set; } = 64;
    }
}
