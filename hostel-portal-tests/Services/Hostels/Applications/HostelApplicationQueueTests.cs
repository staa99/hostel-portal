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
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockHostelApplicationQueueConfiguration = mockRepository.Create<HostelApplicationQueueConfiguration>();
            mockQueueManager = mockRepository.Create<IQueueManager>();
            mockHostelApplicationSerializer = mockRepository.Create<IHostelApplicationSerializer>();
        }


        private MockRepository mockRepository;

        private Mock<HostelApplicationQueueConfiguration> mockHostelApplicationQueueConfiguration;
        private Mock<IQueueManager>                       mockQueueManager;
        private Mock<IHostelApplicationSerializer>        mockHostelApplicationSerializer;


        private HostelApplicationQueue CreateHostelApplicationQueue() =>
            new HostelApplicationQueue(
                mockHostelApplicationQueueConfiguration.Object,
                mockQueueManager.Object,
                mockHostelApplicationSerializer.Object);


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
            mockRepository.VerifyAll();
        }
    }
}