using System;
using FluentAssertions;
using IRIS.Domain.Entities;
using IRIS.Domain.ValueObjects;
using IRIS.TestUtils;
using NUnit.Framework;

namespace IRIS.Domain.UnitTests.Entities
{
    [TestFixture]
    public class AssayTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ShouldCheckName(string name)
        {
            var assayCreateAction = new Func<Assay>(() => new Assay(name, TestData.Users.Default, AssayStatus.Ready(), null, null));

            assayCreateAction.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldCheckOwner()
        {
            var assayCreateAction = new Func<Assay>(() => new Assay("Test", null!, AssayStatus.Ready(), null, null));

            assayCreateAction.Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldConstructSuccessfully()
        {
            var assay = new Assay("test", TestData.Users.Default, AssayStatus.Ready(), null, null);
            
            assay.Status.Should().Be(AssayStatus.Ready());
            assay.Name.Should().Be("test");
            assay.Owner.Email.Should().Be(TestData.Users.Default.Email);
            assay.Owner.ExternalId.Should().Be(TestData.Users.Default.ExternalId);
            assay.Owner.Name.Should().Be(TestData.Users.Default.Name);
            assay.Sessions.Should().BeEmpty();
        }

        [Test]
        public void ShouldSetStatus()
        {
            var assay = new Assay("test", TestData.Users.Default, AssayStatus.Detection(), null, null);
            assay.Status.Should().Be(AssayStatus.Detection());

            assay.SetStatus(AssayStatus.DetectionFailed());

            assay.Status.Should().Be(AssayStatus.DetectionFailed());
        }

        [Test]
        public void ShouldAddSessionToList()
        {
            var assay = new Assay("test", TestData.Users.Default, AssayStatus.Detection(), null, null);
            assay.Sessions.Should().BeEmpty();

            assay.AddSession(new Session{Name = "test session"});

            assay.Sessions.Should().HaveCount(1).And.ContainSingle(s => s.Name == "test session");
        }

        [Test]
        public void ShouldSetRelationshipWhenAddingSessionToList()
        {
            var assay = new Assay("test", TestData.Users.Default, AssayStatus.Detection(), null, null);
            assay.Sessions.Should().BeEmpty();

            assay.AddSession(new Session{Name = "test session"});

            assay.Sessions.Should().HaveCount(1).And.ContainSingle(s => s.Name == "test session" && s.Assay == assay && s.AssayId == assay.Id);
        }
    }
}