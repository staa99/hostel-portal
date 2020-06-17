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
        private const string DummyReference = "DummyReference";
        private const PaymentStatus DummyStatus = PaymentStatus.Initiated;
        private const string DummyMatricNumber = "random-matric-number";

        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private MockRepository mockRepository;

        private static PaymentService CreateService() => new PaymentService();


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
        public async Task GetPaymentRecordAsync_WhenPaymentFromCacheCheckerNotNull_ShouldReturnNull()
        {
            // Arrange
            var service = CreateService();
            var matricNumber = "random-matric-number";
            var cacheCheckerMock = mockRepository.Create<IPaymentCacheChecker>();
            cacheCheckerMock.Setup(checker => checker.GetPaymentRecordAsync(matricNumber))
                            .Returns(Task.FromResult((PaymentDto?) null));
            var cacheChecker = cacheCheckerMock.Object;

            // Act
            var result = await service.GetPaymentRecordAsync(
                             matricNumber,
                             cacheChecker,
                             default,
                             default);

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