using System;
using FluentAssertions;
using NUnit.Framework;

namespace IRIS.Domain.UnitTests.ValueObjects
{
    [TestFixture]
    public class AssayStatusTests
    {
        [Test]
        public void ShouldCheckNegativeProcessedFiles()
        {
            var statusAction = new Func<AssayStatus>(() => AssayStatus.Uploading(-1, 10));

            statusAction.Should().Throw<ArgumentException>().WithMessage("Required input processedFiles cannot be negative. (Parameter 'processedFiles')");
        }
        
        [Test]
        public void ShouldCheckNegativeFilesCount()
        {
            var statusAction = new Func<AssayStatus>(() => AssayStatus.Uploading(0, -1));

            statusAction.Should().Throw<ArgumentException>().WithMessage("Required input filesCount cannot be negative. (Parameter 'filesCount')");
        }

        [Test]
        public void ShouldCheckFilesCountIsGreaterThanProcessed()
        {
            var statusAction = new Func<AssayStatus>(() => AssayStatus.Uploading(10, 9));

            statusAction.Should().Throw<ArgumentException>().WithMessage("Parameter processedFiles must be less or equal to filesCount when specified.");
        }

        [Test]
        public void ShouldConstructSuccessfully()
        {
            var status = AssayStatus.Uploading(1, 10);
            status.FilesCount.Should().Be(10);
            status.ProcessedFiles.Should().Be(1);
            status.Type.Should().Be(AssayStatusEnum.Uploading);
        }

        [Test]
        public void ShouldAllowEqualityComparisonForSimpleTypes()
        {
            Assert.AreEqual(AssayStatus.Detection(), AssayStatus.Detection());
            Assert.AreNotEqual(AssayStatus.Detection(), AssayStatus.Ready());
        }

        [Test]
        public void ShouldAllowEqualityComparisonForComplexType()
        {
            Assert.AreEqual(AssayStatus.Uploading(1,10), AssayStatus.Uploading(1, 10));
            Assert.AreNotEqual(AssayStatus.Uploading(1,10), AssayStatus.Uploading(2, 10));
            Assert.AreNotEqual(AssayStatus.Uploading(1,10), AssayStatus.Uploading(1, 200));
        }
    }
}