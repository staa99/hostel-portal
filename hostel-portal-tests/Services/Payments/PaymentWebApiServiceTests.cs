using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Payments;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class PaymentWebApiServiceTests
    {
        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
        }


        [Test]
        public async Task GetPaymentRecordAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            string matricNumber = null;

            // Act
            var result = await service.GetPaymentRecordAsync(
                             matricNumber);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        [Test]
        public async Task InitiatePaymentAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            string matricNumber = null;

            // Act
            var result = await service.InitiatePaymentAsync(
                             matricNumber);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private PaymentWebApiService CreateService() => new PaymentWebApiService();
    }
}