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

        private MockRepository mockRepository;


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
            mockRepository.VerifyAll();
        }


        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockPaymentConfiguration = mockRepository.Create<PaymentConfiguration>();
            mockRedisCache = mockRepository.Create<IRedisCache>();
            mockHostelApplicationFeeRedisKeyResolver = mockRepository.Create<IHostelApplicationFeeRedisKeyResolver>();
        }


        private PaymentCacheChecker CreatePaymentCacheChecker() =>
            new PaymentCacheChecker(
                mockPaymentConfiguration.Object,
                mockRedisCache.Object,
                mockHostelApplicationFeeRedisKeyResolver.Object);
    }
}