using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Listing
{
    [TestFixture]
    public class HostelCacheCheckerTests
    {
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockRedisCache = mockRepository.Create<IRedisCache>();
        }


        private MockRepository mockRepository;

        private Mock<IRedisCache> mockRedisCache;


        private HostelCacheChecker CreateHostelCacheChecker() =>
            new HostelCacheChecker(
                mockRedisCache.Object);


        [Test]
        public async Task LoadHostels_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelCacheChecker = CreateHostelCacheChecker();

            // Act
            var result = await hostelCacheChecker.LoadHostels();

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}