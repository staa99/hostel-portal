using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Authentication;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Authentication
{
    [TestFixture]
    public class UserAuthenticationServiceTests
    {
        private MockRepository mockRepository;


        [Test]
        public async Task AuthenticateUserAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = CreateService();
            string username = null;
            string password = null;

            // Act
            var result = await service.AuthenticateUserAsync(
                             username,
                             password);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }


        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        private UserAuthenticationService CreateService() => new UserAuthenticationService();
    }
}