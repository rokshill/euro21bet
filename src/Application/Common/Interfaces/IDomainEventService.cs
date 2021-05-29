using System.Threading.Tasks;
using Euro21bet.Domain.Common;

namespace Euro21bet.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
