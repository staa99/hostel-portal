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
        private const string DummyMatricNumber = "random-matric-number";

        private const string        DummyReference = "DummyReference";
        private const PaymentStatus DummyStatus    = PaymentStatus.Initiated;

        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
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

            var cacheChecker = CreatePaymentCacheChecker(payment);

            // Act
            var result = await service.GetPaymentRecordAsync(
                             DummyMatricNumber,
                             cacheChecker,
                             default,
                             default);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(payment),
                () => _mockRepository.VerifyAll()
            );
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
            var cacheUpdater = CreatePaymentCacheUpdater(paymentFromWebApiService);

            // Act
            var result = await service.GetPaymentRecordAsync(
                             DummyMatricNumber,
                             cacheChecker,
                             cacheUpdater,
                             webApiService);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(paymentFromWebApiService),
                () => _mockRepository.VerifyAll()
            );
        }


        [Test]
        public async Task GetPaymentRecordAsync_WhenPaymentFromCacheCheckerNullAndPaymentFromWebApiNull_ShouldReturnNull()
        {
            // Arrange
            var service = CreateService();
            PaymentDto? paymentFromCacheChecker = null;
            PaymentDto? paymentFromWebApiService = null;

            var cacheChecker = CreatePaymentCacheChecker(paymentFromCacheChecker);
            var webApiService = CreatePaymentWebApiService(paymentFromWebApiService);

            // Act
            var result = await service.GetPaymentRecordAsync(
                             DummyMatricNumber,
                             cacheChecker,
                             default,
                             webApiService);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(null),
                () => _mockRepository.VerifyAll()
            );
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
            _mockRepository.VerifyAll();
        }


        private IPaymentCacheChecker CreatePaymentCacheChecker(PaymentDto? paymentFromCacheChecker)
        {
            var cacheCheckerMock = _mockRepository.Create<IPaymentCacheChecker>();
            cacheCheckerMock.Setup(checker => checker.GetPaymentRecordAsync(DummyMatricNumber))
                            .Returns(Task.FromResult(paymentFromCacheChecker));

            var cacheChecker = cacheCheckerMock.Object;
            return cacheChecker;
        }


        private IPaymentCacheUpdater CreatePaymentCacheUpdater(PaymentDto paymentFromWebApiService)
        {
            var cacheUpdaterMock = _mockRepository.Create<IPaymentCacheUpdater>();
            cacheUpdaterMock
               .Setup(updater => updater.UpdatePaymentRecordAsync(DummyMatricNumber, paymentFromWebApiService))
               .Returns(Task.CompletedTask);

            var cacheUpdater = cacheUpdaterMock.Object;
            return cacheUpdater;
        }


        private IPaymentWebApiService CreatePaymentWebApiService(PaymentDto paymentFromWebApiService)
        {
            var webApiServiceMock = _mockRepository.Create<IPaymentWebApiService>();
            webApiServiceMock.Setup(service => service.GetPaymentRecordAsync(DummyMatricNumber))
                             .Returns(Task.FromResult(paymentFromWebApiService));

            var webApiService = webApiServiceMock.Object;
            return webApiService;
        }


        private static PaymentService CreateService() => new PaymentService();
    }
}