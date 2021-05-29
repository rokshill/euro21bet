using System.Threading.Tasks;
using Euro21bet.Application.Common.Interfaces;
using Euro21bet.Domain.Common;

namespace Euro21bet.Infrastructure.Services
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