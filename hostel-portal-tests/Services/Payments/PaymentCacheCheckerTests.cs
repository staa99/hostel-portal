using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Payments;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Config;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class PaymentCacheCheckerTests
    {
        private Mock<IHostelApplicationFeeRedisKeyResolver> mockHostelApplicationFeeRedisKeyResolver;

        private Mock<PaymentConfiguration> mockPaymentConfiguration;
        private Mock<IRedisCache>          mockRedisCache;

        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            mockPaymentConfiguration = _mockRepository.Create<PaymentConfiguration>();
            mockRedisCache = _mockRepository.Create<IRedisCache>();
            mockHostelApplicationFeeRedisKeyResolver = _mockRepository.Create<IHostelApplicationFeeRedisKeyResolver>();
        }


        [Test]
        public async Task GetPaymentRecordAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var paymentCacheChecker = CreatePaymentCacheChecker();
            string matricNumber = null;

            // Act
            var result = await paymentCacheChecker.GetPaymentRecordAsync(
                             matricNumber);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private PaymentCacheChecker CreatePaymentCacheChecker() =>
            new PaymentCacheChecker(
                mockPaymentConfiguration.Object,
                mockRedisCache.Object,
                mockHostelApplicationFeeRedisKeyResolver.Object);
    }
}