using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Payments;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class HostelFeeRedisKeyResolverTests
    {
        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private MockRepository mockRepository;

        private HostelFeeRedisKeyResolver CreateHostelFeeRedisKeyResolver() => new HostelFeeRedisKeyResolver();


        [Test]
        public void Resolve_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelFeeRedisKeyResolver = CreateHostelFeeRedisKeyResolver();
            string source = null;

            // Act
            var result = hostelFeeRedisKeyResolver.Resolve(
                source);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}