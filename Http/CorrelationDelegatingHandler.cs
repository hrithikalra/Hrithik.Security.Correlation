using Hrithik.Security.Correlation.Abstractions;
using Hrithik.Security.Correlation.Core;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Hrithik.Security.Correlation.Http
{
    /// <summary>
    /// HTTP message handler that propagates the correlation identifier
    /// to outgoing HTTP requests.
    /// </summary>
    public sealed class CorrelationDelegatingHandler : DelegatingHandler
    {
        private readonly ICorrelationContext _context;
        private readonly CorrelationOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationDelegatingHandler"/> class.
        /// </summary>
        public CorrelationDelegatingHandler(
            ICorrelationContext context,
            CorrelationOptions options)
        {
            _context = context;
            _options = options;
        }

        /// <inheritdoc />
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains(_options.HeaderName))
            {
                request.Headers.Add(
                    _options.HeaderName,
                    _context.CorrelationId);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
