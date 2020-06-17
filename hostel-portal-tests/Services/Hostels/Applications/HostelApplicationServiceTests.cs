using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Applications
{
    [TestFixture]
    public class HostelApplicationServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private MockRepository mockRepository;

        private HostelApplicationService CreateService() => new HostelApplicationService();


        [Test]
        public async Task CheckHostelApplicationStatusAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            string matricNumber = null;
            IHostelApplicationCacheChecker cacheChecker = null;

            // Act
            var result = await service.CheckHostelApplicationStatusAsync(
                             matricNumber,
                             cacheChecker);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }


        [Test]
        public async Task CheckSingleHostelApplicationStatusAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            HostelApplicationDto hostelApplicationData = null;
            IHostelApplicationCacheChecker cacheChecker = null;

            // Act
            var result = await service.CheckSingleHostelApplicationStatusAsync(
                             hostelApplicationData,
                             cacheChecker);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }


        [Test]
        public async Task InitiateHostelApplicationAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            HostelApplicationDto hostelApplicationData = null;
            IHostelApplicationQueue hostelApplicationQueue = null;
            IHostelApplicationCacheChecker cacheChecker = null;
            IHostelApplicationCacheUpdater cacheUpdater = null;

            // Act
            var result = await service.InitiateHostelApplicationAsync(
                             hostelApplicationData,
                             hostelApplicationQueue,
                             cacheChecker,
                             cacheUpdater);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}