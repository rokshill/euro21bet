using NUnit.Framework;
using System.Threading.Tasks;
using IRIS.Infrastructure.Persistence;

namespace IRIS.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        protected static ApplicationDbContext Context { get; } = GetContext();

        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
            Seed.Generic();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            await Context.DisposeAsync();
        }
    }
}
