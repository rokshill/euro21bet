using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentForm.Domain.Entities;

namespace TournamentForm.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Item> Items { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
