using Hrithik.Security.Correlation.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hrithik.Security.Correlation.AspNetCore
{
    /// <summary>
    /// Middleware that manages correlation identifiers for incoming HTTP requests.
    /// </summary>
    public sealed class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CorrelationOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationMiddleware"/> class.
        /// </summary>
        public CorrelationMiddleware(
            RequestDelegate next,
            IOptions<CorrelationOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        /// <summary>
        /// Processes the HTTP request and ensures a correlation ID is available.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            var headerName = _options.HeaderName;
            var correlationId = context.Request.Headers[headerName].ToString();

            if (string.IsNullOrWhiteSpace(correlationId))
            {
                if (!_options.GenerateIfMissing)
                    throw new InvalidOperationException("Missing correlation identifier.");

                correlationId = CorrelationIdGenerator.Generate();
            }

            Validate(correlationId);

            CorrelationContext.Set(correlationId);

            context.Response.Headers[headerName] = correlationId;

            await _next(context);
        }

        private void Validate(string correlationId)
        {
            if (!_options.StrictValidation)
                return;

            if (correlationId.Length > _options.MaxLength)
                throw new InvalidOperationException("Invalid correlation identifier.");
        }
    }
}
