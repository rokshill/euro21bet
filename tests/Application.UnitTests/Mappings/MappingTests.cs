using System;
using System.Runtime.Serialization;
using AutoMapper;
using FluentAssertions;
using IRIS.Application.Assays.Queries.GetAssaysWithSearchAndPagination;
using IRIS.Application.Common.Mappings;
using IRIS.Application.Sessions.Queries;
using IRIS.Application.Users;
using IRIS.Domain.Entities;
using IRIS.Domain.ValueObjects;
using NUnit.Framework;

namespace IRIS.Application.UnitTests.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Test]
        [TestCase(typeof(Assay), typeof(AssayDto))]
        [TestCase(typeof(User), typeof(UserDto))]
        [TestCase(typeof(Session), typeof(SessionDto))]
        [TestCase(typeof(AssayStatus), typeof(AssayStatusDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
        

        [Test]
        public void ShouldMapAssayWithStatus()
        {
            var status = AssayStatus.Uploading(10, 100);
            var assay = new Assay("test", new User(Guid.Empty, "test@test.com", "Test Testy"), status, null, null);
            var obj = _mapper.Map<AssayDto>(assay);

            obj.Should().NotBeNull();
            obj.Status.Type.Should().Be("Uploading");
            obj.Status.FilesCount.Should().Be(100);
            obj.Status.ProcessedFiles.Should().Be(10);

        }
    }
}
