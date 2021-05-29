using System;
using AutoMapper;
using IRIS.Application.Common.Interfaces.Identity;
using IRIS.Application.Common.Mappings;
using Moq;

namespace IRIS.Application.UnitTests
{
    public class TestBase
    {
        protected ICurrentUserProvider CurrentUserProvider;
        private Guid _currentUserId = Guid.Empty;
        private Mock<ICurrentUserProvider> _currentUserProviderMock;

        protected IMapper Mapper { get; private set; }

        protected TestBase()
        {
            ConfigureMapper();
            ConfigureCurrentUserProvider();
        }

        private void ConfigureMapper()
        {
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }

        private void ConfigureCurrentUserProvider()
        {
            _currentUserProviderMock = new Mock<ICurrentUserProvider>();
            _currentUserProviderMock.Setup(x => x.GetExternalId()).Returns(() => _currentUserId);
            CurrentUserProvider = _currentUserProviderMock.Object;
        }

        protected void SetCurrentUserId(Guid guid)
        {
            _currentUserId = guid;
        }
    }
}