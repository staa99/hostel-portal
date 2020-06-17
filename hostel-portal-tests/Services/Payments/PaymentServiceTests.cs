using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shouldly;
using Staawork.Funaab.HostelPortal.Services.Payments;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class PaymentServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private MockRepository mockRepository;

        private PaymentService CreateService() => new PaymentService();


        [Test]
        public async Task GetPaymentRecordAsync_WhenPaymentFromCacheCheckerNull_ShouldReturnNull()
        {
            // Arrange
            var service = CreateService();
            string matricNumber = "random-matric-number";
            var cacheCheckerMock = mockRepository.Create<IPaymentCacheChecker>();
            cacheCheckerMock.Setup(checker => checker.GetPaymentRecordAsync(matricNumber))
                            .Returns(Task.FromResult((PaymentDto?) null));
            IPaymentCacheChecker cacheChecker = cacheCheckerMock.Object;
            IPaymentCacheUpdater cacheUpdater = null;
            IPaymentWebApiService webApiService = null;

            // Act
            var result = await service.GetPaymentRecordAsync(
                             matricNumber,
                             cacheChecker,
                             cacheUpdater,
                             webApiService);

            // Assert
            result.ShouldBe(null);
            mockRepository.VerifyAll();
        }


        [Test]
        public async Task GetPaymentRecordAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            string matricNumber = null;
            IPaymentCacheChecker cacheChecker = null;
            IPaymentCacheUpdater cacheUpdater = null;
            IPaymentWebApiService webApiService = null;

            // Act
            var result = await service.GetPaymentRecordAsync(
                             matricNumber,
                             cacheChecker,
                             cacheUpdater,
                             webApiService);

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
            IPaymentCacheChecker cacheChecker = null;
            IPaymentCacheUpdater cacheUpdater = null;
            IPaymentWebApiService webApiService = null;

            // Act
            var result = await service.InitiatePaymentAsync(
                             matricNumber,
                             cacheChecker,
                             cacheUpdater,
                             webApiService);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}