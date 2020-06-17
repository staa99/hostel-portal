using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Applications
{
    [TestFixture]
    public class HostelApplicationCacheCheckerTests
    {
        private Mock<IHostelApplicationRedisKeyResolver> mockHostelApplicationRedisKeyResolver;

        private Mock<IRedisCache> mockRedisCache;

        private MockRepository mockRepository;


        [Test]
        public async Task CheckHostelApplicationStatusAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelApplicationCacheChecker = CreateHostelApplicationCacheChecker();
            string matricNumber = null;

            // Act
            var result = await hostelApplicationCacheChecker.CheckHostelApplicationStatusAsync(
                             matricNumber);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }


        [Test]
        public async Task CheckSingleHostelApplicationStatusAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelApplicationCacheChecker = CreateHostelApplicationCacheChecker();
            HostelApplicationDto applicationData = null;

            // Act
            var result = await hostelApplicationCacheChecker.CheckSingleHostelApplicationStatusAsync(
                             applicationData);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }


        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockRedisCache = mockRepository.Create<IRedisCache>();
            mockHostelApplicationRedisKeyResolver = mockRepository.Create<IHostelApplicationRedisKeyResolver>();
        }


        private HostelApplicationCacheChecker CreateHostelApplicationCacheChecker() =>
            new HostelApplicationCacheChecker(
                mockRedisCache.Object,
                mockHostelApplicationRedisKeyResolver.Object);
    }
}