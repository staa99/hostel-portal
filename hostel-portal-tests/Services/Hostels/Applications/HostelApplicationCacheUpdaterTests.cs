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
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockRedisCache = mockRepository.Create<IRedisCache>();
            mockHostelApplicationRedisKeyResolver = mockRepository.Create<IHostelApplicationRedisKeyResolver>();
        }


        private MockRepository mockRepository;

        private Mock<IRedisCache>                        mockRedisCache;
        private Mock<IHostelApplicationRedisKeyResolver> mockHostelApplicationRedisKeyResolver;


        private HostelApplicationCacheUpdater CreateHostelApplicationCacheUpdater() =>
            new HostelApplicationCacheUpdater(
                mockRedisCache.Object,
                mockHostelApplicationRedisKeyResolver.Object);


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
            mockRepository.VerifyAll();
        }
    }
}