using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Payments;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Config;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class PaymentCacheUpdaterTests
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
        public async Task UpdatePaymentRecordAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var paymentCacheUpdater = CreatePaymentCacheUpdater();
            string matricNumber = null;
            PaymentDto paymentRecord = null;

            // Act
            await paymentCacheUpdater.UpdatePaymentRecordAsync(
                matricNumber,
                paymentRecord);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private PaymentCacheUpdater CreatePaymentCacheUpdater() =>
            new PaymentCacheUpdater(
                mockPaymentConfiguration.Object,
                mockRedisCache.Object,
                mockHostelApplicationFeeRedisKeyResolver.Object);
    }
}