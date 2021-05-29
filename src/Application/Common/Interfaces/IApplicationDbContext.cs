using System.Threading;
using System.Threading.Tasks;
using Euro21bet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Euro21bet.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Group> Groups { get; set; }

        DbSet<Team> Teams { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
