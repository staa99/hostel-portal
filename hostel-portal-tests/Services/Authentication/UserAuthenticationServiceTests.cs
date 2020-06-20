using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Authentication;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Authentication
{
    [TestFixture]
    public class UserAuthenticationServiceTests
    {
        private MockRepository _mockRepository;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
        }


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
            _mockRepository.VerifyAll();
        }


        private UserAuthenticationService CreateService() => new UserAuthenticationService();
    }
}