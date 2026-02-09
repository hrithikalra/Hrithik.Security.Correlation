using Microsoft.Extensions.DependencyInjection;
using Hrithik.Security.Correlation.Abstractions;
using Hrithik.Security.Correlation.Core;
using System;

namespace Hrithik.Security.Correlation
{
    /// <summary>
    /// Dependency injection extensions for correlation services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers correlation services.
        /// </summary>
        public static IServiceCollection AddCorrelation(
            this IServiceCollection services,
            Action<CorrelationOptions>? configure = null)
        {
            var options = new CorrelationOptions();
            configure?.Invoke(options);

            services.AddSingleton(options);
            services.AddSingleton<ICorrelationContext, CorrelationContext>();

            return services;
        }
    }
}
