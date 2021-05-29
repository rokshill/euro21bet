using IRIS.Application.Common.Interfaces;
using IRIS.Domain.Entities;
using IRIS.Infrastructure.Persistence;
using IRIS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace IRIS.Application.UnitTests
{
    public class ContextTestBase : TestBase
    {
        protected IApplicationDbContext Context { get; }

        protected ContextTestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("IRISUnitTestsDatabase")
                .Options;

            Context = new ApplicationDbContext(options, CurrentUserProvider, new NullDomainEventService(), new DateTimeService());
            Seed();
        }

        private void Seed()
        {
            Context.Users.Add(new User(CurrentUserProvider.GetExternalId(), "test@test.com", "Test Testy"));
            Context.SaveChanges();
        }
    }
}