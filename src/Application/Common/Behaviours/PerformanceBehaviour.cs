using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Euro21bet.Application.Common.Interfaces.Identity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Euro21bet.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentIdentityUserProvider _currentIdentityUserProvider;

        public PerformanceBehaviour(
            ILogger<TRequest> logger,
            ICurrentIdentityUserProvider currentIdentityUserProvider)
        {
            _currentIdentityUserProvider = currentIdentityUserProvider;
            _timer = new Stopwatch();

            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogWarning(
                    "Euro21bet Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                    requestName, elapsedMilliseconds, _currentIdentityUserProvider.Email, request);
            }

            return response;
        }
    }
}
