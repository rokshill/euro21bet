using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using TournamentForm.Application.Common.Interfaces.Identity;

namespace TournamentForm.Application.Common.Behaviours
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

            _logger.LogInformation("TournamnetForm Request: {Name} {Email} {@Request}",
                requestName, _currentIdentityUserProvider.Email, request);
        }
    }
}