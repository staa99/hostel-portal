using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Payments;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class HostelApplicationFeeRedisKeyResolverTests
    {
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private MockRepository mockRepository;


        private HostelApplicationFeeRedisKeyResolver CreateHostelApplicationFeeRedisKeyResolver() =>
            new HostelApplicationFeeRedisKeyResolver();


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
            mockRepository.VerifyAll();
        }
    }
}