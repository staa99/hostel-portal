using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Applications
{
    [TestFixture]
    public class HostelApplicationCacheUpdaterTests
    {
        private Mock<IHostelApplicationRedisKeyResolver> mockHostelApplicationRedisKeyResolver;

        private Mock<IRedisCache> mockRedisCache;

        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            mockRedisCache = _mockRepository.Create<IRedisCache>();
            mockHostelApplicationRedisKeyResolver = _mockRepository.Create<IHostelApplicationRedisKeyResolver>();
        }


        [Test]
        public async Task UpdateHostelApplicationStatusAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelApplicationCacheUpdater = CreateHostelApplicationCacheUpdater();
            HostelApplicationDto applicationDto = null;
            HostelApplicationStatus newStatus = default;

            // Act
            await hostelApplicationCacheUpdater.UpdateHostelApplicationStatusAsync(
                applicationDto,
                newStatus);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private HostelApplicationCacheUpdater CreateHostelApplicationCacheUpdater() =>
            new HostelApplicationCacheUpdater(
                mockRedisCache.Object,
                mockHostelApplicationRedisKeyResolver.Object);
    }
}