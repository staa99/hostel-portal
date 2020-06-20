using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Payments;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class HostelApplicationFeeRedisKeyResolverTests
    {
        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
        }


        [Test]
        public void Resolve_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelApplicationFeeRedisKeyResolver = CreateHostelApplicationFeeRedisKeyResolver();
            string source = null;

            // Act
            var result = hostelApplicationFeeRedisKeyResolver.Resolve(
                source);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private HostelApplicationFeeRedisKeyResolver CreateHostelApplicationFeeRedisKeyResolver() =>
            new HostelApplicationFeeRedisKeyResolver();
    }
}