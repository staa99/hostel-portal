using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Payments;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class PaymentWebApiServiceTests
    {
        private MockRepository mockRepository;


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
            mockRepository.VerifyAll();
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
            mockRepository.VerifyAll();
        }


        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private PaymentWebApiService CreateService() => new PaymentWebApiService();
    }
}