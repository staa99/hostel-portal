using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Listing
{
    [TestFixture]
    public class HostelLoaderTests
    {
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private MockRepository mockRepository;

        private HostelLoader CreateHostelLoader() => new HostelLoader();


        [Test]
        public async Task LoadHostels_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelLoader = CreateHostelLoader();
            IHostelCacheChecker cacheChecker = null;
            IHostelCacheUpdater cacheUpdater = null;
            IHostelWebApiLoader webApiLoader = null;

            // Act
            var result = await hostelLoader.LoadHostels(
                             cacheChecker,
                             cacheUpdater,
                             webApiLoader);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}