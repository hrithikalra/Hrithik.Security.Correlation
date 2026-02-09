using Microsoft.AspNetCore.Builder;

namespace Hrithik.Security.Correlation.AspNetCore
{
    /// <summary>
    /// Extension methods for registering correlation middleware.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds correlation handling middleware to the request pipeline.
        /// </summary>
        public static IApplicationBuilder UseCorrelation(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationMiddleware>();
        }
    }
}
