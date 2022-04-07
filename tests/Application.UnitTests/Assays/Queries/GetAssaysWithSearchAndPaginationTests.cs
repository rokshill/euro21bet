using System.Threading;
using System.Threading.Tasks;
using IRIS.TestUtils;
using NUnit.Framework;

namespace IRIS.Application.UnitTests.Assays.Queries
{
    [TestFixture]
    public class GetAssaysWithSearchAndPaginationTests : ContextTestBase
    {
        private readonly GetAssaysWithSearchAndPaginationQueryHandler _handler;

        public GetAssaysWithSearchAndPaginationTests()
        {
            var assays = new[]
            {
                new Assay("three - 1", TestData.Users.Sarah, AssayStatus.Ready(), null, null),
                new Assay("three - 2", TestData.Users.Sarah, AssayStatus.Ready(), null, null),
                new Assay("one - 1", TestData.Users.Default, AssayStatus.Ready(), null, null),
                new Assay("one - 2", TestData.Users.Default, AssayStatus.Ready(), null, null),
                new Assay("two - 1", TestData.Users.John, AssayStatus.Ready(), null, null),
                new Assay("two - 2", TestData.Users.John, AssayStatus.Ready(), null, null)
            };
            Context.Assays.AddRange(assays);
            Context.SaveChanges();

            SetCurrentUserId(TestData.Users.John.ExternalId);

            _handler = new GetAssaysWithSearchAndPaginationQueryHandler(Context, Mapper, CurrentUserProvider);
        }

        [Test]
        public async Task ShouldFilterByString()
        {
            var query = new GetAssaysWithSearchAndPaginationQuery {SearchQuery = "2"};

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Items.Select(a => a.Name).Should().HaveCount(1)
                .And.BeEquivalentTo(new[] {"two - 2"});
        }

        [Test]
        public async Task ShouldFilterByOnlyMineFalse()
        {
            var query = new GetAssaysWithSearchAndPaginationQuery {OnlyMine = false};

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Items.Select(a => a.Name).Should().HaveCount(6)
                .And.BeEquivalentTo(new[] {"three - 1", "three - 2", "one - 1", "one - 2", "two - 1", "two - 2"});
        }

        [Test]
        public async Task ShouldFilterByOnlyMineTrue()
        {
            var query = new GetAssaysWithSearchAndPaginationQuery {OnlyMine = true};

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Items.Select(a => a.Name).Should().HaveCount(2)
                .And.BeEquivalentTo(new[] {"two - 1", "two - 2"});
        }

        [Test]
        public async Task ShouldSortBySpecification_CreatedAscending()
        {
            var query = new GetAssaysWithSearchAndPaginationQuery
            {
                SortSpecification = SortSpecification.Build(nameof(Assay.Name), OrderEnum.Ascending),
                OnlyMine = false
            };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Items.Select(a => a.Name).Should().HaveCount(6)
                .And.BeEquivalentTo(new []{"one - 1", "one - 2", "three - 1", "three - 2", "two - 1", "two - 2"}, o => o.WithStrictOrdering());
        }

        [Test]
        public async Task ShouldSortBySpecification_CreatedDescending()
        {
            var query = new GetAssaysWithSearchAndPaginationQuery
            {
                SortSpecification = SortSpecification.Build(nameof(Assay.Name), OrderEnum.Descending),
                OnlyMine = false
            };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Items.Select(a => a.Name).Should().HaveCount(6)
                .And.BeEquivalentTo(new []{"two - 2", "two - 1", "three - 2", "three - 1", "one - 2", "one - 1"}, o => o.WithStrictOrdering());
        }

        [Test]
        public async Task ShouldReturnOnlyMineByDefault()
        {
            var query = new GetAssaysWithSearchAndPaginationQuery();

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Items.Select(a => a.Name).Should().HaveCount(2)
                .And.BeEquivalentTo(new []{"two - 2", "two - 1"});
        }
    }
}
