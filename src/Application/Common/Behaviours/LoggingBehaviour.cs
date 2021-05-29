using System.Threading;
using System.Threading.Tasks;
using Euro21bet.Application.Common.Interfaces.Identity;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Euro21bet.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentIdentityUserProvider _currentIdentityUserProvider;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentIdentityUserProvider currentIdentityUserProvider)
        {
            _logger = logger;
            _currentIdentityUserProvider = currentIdentityUserProvider;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("Euro21bet Request: {Name} {Email} {@Request}",
                requestName, _currentIdentityUserProvider.Email, request);
        }
    }
}