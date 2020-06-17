using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Hostels.Applications
{
    [TestFixture]
    public class HostelApplicationRedisKeyResolverTests
    {
        private MockRepository mockRepository;


        [Test]
        public void Resolve_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var hostelApplicationRedisKeyResolver = CreateHostelApplicationRedisKeyResolver();
            string source = null;

            // Act
            var result = hostelApplicationRedisKeyResolver.Resolve(
                source);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }


        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private HostelApplicationRedisKeyResolver CreateHostelApplicationRedisKeyResolver() =>
            new HostelApplicationRedisKeyResolver();
    }
}