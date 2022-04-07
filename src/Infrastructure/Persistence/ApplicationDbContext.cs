using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentForm.Application.Common.Interfaces;
using TournamentForm.Application.Common.Interfaces.Identity;
using TournamentForm.Domain.Common;
using TournamentForm.Domain.Entities;

namespace TournamentForm.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly IDomainEventService _domainEventService;
        private readonly ICurrentIdentityUserProvider _currentIdentityUserProvider;

        public ApplicationDbContext(
            DbContextOptions options,
            ICurrentIdentityUserProvider currentIdentityUserProvider,
            IDomainEventService domainEventService,
            IDateTime dateTime) : base(options)
        {
            _currentIdentityUserProvider = currentIdentityUserProvider;
            _domainEventService = domainEventService;
            _dateTime = dateTime;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            HandleAuditableEntities();

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents();

            return result;
        }

        public override int SaveChanges()
        {
            HandleAuditableEntities();

            var result = base.SaveChanges();

            DispatchEvents().Wait();

            return result;
        }

        private void HandleAuditableEntities()
        {
            var auditableEntries = ChangeTracker.Entries<AuditableEntity>().ToList();
            if (auditableEntries.Any())
            {
                var dateTimeNow = _dateTime.Now;
                var currentUserEmail = _currentIdentityUserProvider.Email;
                foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in auditableEntries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = currentUserEmail;
                            entry.Entity.Created = dateTimeNow;
                            entry.Entity.LastModifiedBy = currentUserEmail;
                            entry.Entity.LastModified = dateTimeNow;
                            break;

                        case EntityState.Modified:
                            entry.Entity.LastModifiedBy = currentUserEmail;
                            entry.Entity.LastModified = dateTimeNow;
                            break;
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("tournamentform");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker
                    .Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);
                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }
    }
}
