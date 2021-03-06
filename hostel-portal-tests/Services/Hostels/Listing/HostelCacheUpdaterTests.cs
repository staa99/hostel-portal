using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Listing
{
    [TestFixture]
    public class HostelCacheUpdaterTests
    {
        private Mock<IRedisCache> mockRedisCache;

        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            mockRedisCache = _mockRepository.Create<IRedisCache>();
        }


        [Test]
        public async Task UpdateHostels_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelCacheUpdater = CreateHostelCacheUpdater();
            IEnumerable<HostelDto> hostels = null;

            // Act
            await hostelCacheUpdater.UpdateHostels(
                hostels);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private HostelCacheUpdater CreateHostelCacheUpdater() =>
            new HostelCacheUpdater(
                mockRedisCache.Object);
    }
}