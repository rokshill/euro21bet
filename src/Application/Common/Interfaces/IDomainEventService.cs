using System.Threading.Tasks;
using TournamentForm.Domain.Common;

namespace TournamentForm.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
