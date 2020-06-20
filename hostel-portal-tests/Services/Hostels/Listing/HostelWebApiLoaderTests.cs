using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Listing
{
    [TestFixture]
    public class HostelWebApiLoaderTests
    {
        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
        }


        [Test]
        public async Task LoadHostels_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelWebApiLoader = CreateHostelWebApiLoader();

            // Act
            var result = await hostelWebApiLoader.LoadHostels();

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private HostelWebApiLoader CreateHostelWebApiLoader() => new HostelWebApiLoader();
    }
}