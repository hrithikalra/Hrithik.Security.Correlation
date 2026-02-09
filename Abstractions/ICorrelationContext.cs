namespace Hrithik.Security.Correlation.Abstractions
{
    /// <summary>
    /// Provides access to the current correlation identifier.
    /// This value is expected to remain constant for the lifetime of a request.
    /// </summary>
    public interface ICorrelationContext
    {
        /// <summary>
        /// Gets the current correlation identifier.
        /// </summary>
        string CorrelationId { get; }
    }
}
