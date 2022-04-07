using System.Threading.Tasks;
using TournamentForm.Application.Common.Interfaces;
using TournamentForm.Domain.Common;

namespace TournamentForm.Infrastructure.Services
{
    public class NullDomainEventService : IDomainEventService
    {
        public Task Publish(DomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }

        public static IDomainEventService Instance => new NullDomainEventService();
    }
}