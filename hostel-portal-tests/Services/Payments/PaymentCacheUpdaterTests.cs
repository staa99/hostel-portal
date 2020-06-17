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
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockPaymentConfiguration = mockRepository.Create<PaymentConfiguration>();
            mockRedisCache = mockRepository.Create<IRedisCache>();
            mockHostelApplicationFeeRedisKeyResolver = mockRepository.Create<IHostelApplicationFeeRedisKeyResolver>();
        }


        private MockRepository mockRepository;

        private Mock<PaymentConfiguration>                  mockPaymentConfiguration;
        private Mock<IRedisCache>                           mockRedisCache;
        private Mock<IHostelApplicationFeeRedisKeyResolver> mockHostelApplicationFeeRedisKeyResolver;


        private PaymentCacheUpdater CreatePaymentCacheUpdater() =>
            new PaymentCacheUpdater(
                mockPaymentConfiguration.Object,
                mockRedisCache.Object,
                mockHostelApplicationFeeRedisKeyResolver.Object);


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
            mockRepository.VerifyAll();
        }
    }
}