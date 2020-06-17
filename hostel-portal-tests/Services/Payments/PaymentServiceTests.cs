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


        private const string        DummyReference    = "DummyReference";
        private const PaymentStatus DummyStatus       = PaymentStatus.Initiated;
        private const string        DummyMatricNumber = "random-matric-number";

        private MockRepository mockRepository;

        private static PaymentService CreateService() => new PaymentService();


        private IPaymentWebApiService CreatePaymentWebApiService(PaymentDto paymentFromWebApiService)
        {
            var webApiServiceMock = mockRepository.Create<IPaymentWebApiService>();
            webApiServiceMock.Setup(service => service.GetPaymentRecordAsync(DummyMatricNumber))
                             .Returns(Task.FromResult(paymentFromWebApiService));

            var webApiService = webApiServiceMock.Object;
            return webApiService;
        }


        private IPaymentCacheChecker CreatePaymentCacheChecker(PaymentDto? paymentFromCacheChecker)
        {
            var cacheCheckerMock = mockRepository.Create<IPaymentCacheChecker>();
            cacheCheckerMock.Setup(checker => checker.GetPaymentRecordAsync(DummyMatricNumber))
                            .Returns(Task.FromResult(paymentFromCacheChecker));

            var cacheChecker = cacheCheckerMock.Object;
            return cacheChecker;
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
        public async Task GetPaymentRecordAsync_WhenPaymentFromCacheCheckerNotNull_ShouldReturnPaymentFromCacheChecker()
        {
            // Arrange
            var service = CreateService();
            var payment = new PaymentDto
            {
                Status = DummyStatus,
                Reference = DummyReference
            };

            var cacheCheckerMock = mockRepository.Create<IPaymentCacheChecker>();
            cacheCheckerMock.Setup(checker => checker.GetPaymentRecordAsync(DummyMatricNumber))
                            .Returns(Task.FromResult(payment));

            var cacheChecker = cacheCheckerMock.Object;

            // Act
            var result = await service.GetPaymentRecordAsync(
                             DummyMatricNumber,
                             cacheChecker,
                             default,
                             default);

            // Assert
            result.ShouldBe(payment);
            mockRepository.VerifyAll();
        }


        [Test]
        public async Task GetPaymentRecordAsync_WhenPaymentFromCacheCheckerNull_ShouldReturnPaymentFromWebApi()
        {
            // Arrange
            var service = CreateService();
            PaymentDto? paymentFromCacheChecker = null;
            var paymentFromWebApiService = new PaymentDto
            {
                Status = DummyStatus,
                Reference = DummyReference
            };

            var cacheChecker = CreatePaymentCacheChecker(paymentFromCacheChecker);

            var webApiService = CreatePaymentWebApiService(paymentFromWebApiService);

            // Act
            var result = await service.GetPaymentRecordAsync(
                             DummyMatricNumber,
                             cacheChecker,
                             default,
                             webApiService);

            // Assert
            result.ShouldBe(paymentFromCacheChecker);
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