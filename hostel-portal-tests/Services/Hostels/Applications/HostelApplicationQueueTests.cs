using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Commons.MessageQueue;
using Staawork.Funaab.HostelPortal.Commons.MessageQueue.Config;
using Staawork.Funaab.HostelPortal.Commons.Serialization;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Applications
{
    [TestFixture]
    public class HostelApplicationQueueTests
    {
        private Mock<HostelApplicationQueueConfiguration> mockHostelApplicationQueueConfiguration;
        private Mock<IHostelApplicationSerializer>        mockHostelApplicationSerializer;
        private Mock<IQueueManager>                       mockQueueManager;

        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            mockHostelApplicationQueueConfiguration = _mockRepository.Create<HostelApplicationQueueConfiguration>();
            mockQueueManager = _mockRepository.Create<IQueueManager>();
            mockHostelApplicationSerializer = _mockRepository.Create<IHostelApplicationSerializer>();
        }


        [Test]
        public async Task SendNewHostelApplicationAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelApplicationQueue = CreateHostelApplicationQueue();
            HostelApplicationDto hostelApplicationData = null;

            // Act
            await hostelApplicationQueue.SendNewHostelApplicationAsync(
                hostelApplicationData);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private HostelApplicationQueue CreateHostelApplicationQueue() =>
            new HostelApplicationQueue(
                mockHostelApplicationQueueConfiguration.Object,
                mockQueueManager.Object,
                mockHostelApplicationSerializer.Object);
    }
}