using System.Linq;
using FluentAssertions;
using IRIS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IRIS.Application.IntegrationTests
{
    [TestFixture]
    public class AssayTests : TestBase
    {
        [Test]
        public void ShouldMaterializeHierarchy()
        {
            var assays = Context.Assays.Include(a => a.Sessions).ToList();
            assays.Should().HaveCount(2);
            assays.Select(a => a.Status).Should().NotContainNulls();
            
            var ready = assays.Single(a => a.Status.Type == AssayStatusEnum.Ready);
            var uploading = assays.Single(a => a.Status.Type == AssayStatusEnum.Uploading);

            uploading.Status.FilesCount.Should().Be(100);
            uploading.Status.ProcessedFiles.Should().Be(10);

            ready.Sessions.Should().HaveCount(1);
        }
    }
}