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
            var webApiService = CreatePaymentWebApiServiceForGetPaymentRecord(paymentFromWebApiService);
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
        public async Task
            GetPaymentRecordAsync_WhenPaymentFromCacheCheckerNullAndPaymentFromWebApiNull_ShouldReturnNull()
        {
            // Arrange
            var service = CreateService();
            PaymentDto? paymentFromCacheChecker = null;
            PaymentDto? paymentFromWebApiService = null;

            var cacheChecker = CreatePaymentCacheChecker(paymentFromCacheChecker);
            var webApiService = CreatePaymentWebApiServiceForGetPaymentRecord(paymentFromWebApiService);

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
        public async Task InitiatePaymentAsync_WhenPaymentNotPaid_ShouldInitiatePaymentAndUpdateCache()
        {
            // Arrange
            var service = CreateService();
            var payment = new PaymentDto
            {
                Status = DummyStatus,
                Reference = DummyReference
            };

            var initiatePaymentResultPayment = new PaymentDto
            {
                Reference = DummyReference,
                Status = PaymentStatus.Initiated
            };

            var initiatePaymentResult = new InitiatePaymentResultDto
            {
                PaymentInfo = initiatePaymentResultPayment,
                Message = "Payment initiated"
            };

            var cacheChecker = CreatePaymentCacheChecker(payment);
            var cacheUpdater = CreatePaymentCacheUpdater(initiatePaymentResultPayment);
            var webApiService = CreatePaymentWebApiServiceForInitiatePaymentResult(initiatePaymentResult);

            // Act
            var result = await service.InitiatePaymentAsync(
                             DummyMatricNumber,
                             cacheChecker,
                             cacheUpdater,
                             webApiService);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(initiatePaymentResult),
                () => _mockRepository.VerifyAll()
            );
        }


        [Test]
        public async Task InitiatePaymentAsync_WhenPaymentStatusPaid_ShouldReturnAlreadyPaidResponse()
        {
            // Arrange
            var service = CreateService();
            var payment = new PaymentDto
            {
                Status = PaymentStatus.Paid,
                Reference = DummyReference
            };

            var cacheChecker = CreatePaymentCacheChecker(payment);
            IPaymentCacheUpdater cacheUpdater = null;
            IPaymentWebApiService webApiService = null;

            // Act
            var result = await service.InitiatePaymentAsync(
                             DummyMatricNumber,
                             cacheChecker,
                             cacheUpdater,
                             webApiService);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Message.ShouldBe(PaymentService.AlreadyPaidMessage),
                () => result.PaymentInfo.ShouldBe(payment),
                () => _mockRepository.VerifyAll()
            );
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


        private IPaymentWebApiService CreatePaymentWebApiServiceForGetPaymentRecord(PaymentDto paymentFromWebApiService)
        {
            var webApiServiceMock = _mockRepository.Create<IPaymentWebApiService>();
            webApiServiceMock.Setup(service => service.GetPaymentRecordAsync(DummyMatricNumber))
                             .Returns(Task.FromResult(paymentFromWebApiService));

            var webApiService = webApiServiceMock.Object;
            return webApiService;
        }


        private IPaymentWebApiService CreatePaymentWebApiServiceForInitiatePaymentResult(
            InitiatePaymentResultDto initiatePaymentResultDto)
        {
            var webApiServiceMock = _mockRepository.Create<IPaymentWebApiService>();
            webApiServiceMock.Setup(service => service.InitiatePaymentAsync(DummyMatricNumber))
                             .Returns(Task.FromResult(initiatePaymentResultDto));

            var webApiService = webApiServiceMock.Object;
            return webApiService;
        }


        private static PaymentService CreateService() => new PaymentService();
    }
}