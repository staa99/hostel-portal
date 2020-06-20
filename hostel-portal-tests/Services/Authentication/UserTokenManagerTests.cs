using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Moq;
using NUnit.Framework;
using Staawork.Funaab.HostelPortal.Services.Authentication;
using Staawork.Funaab.HostelPortal.Services.Authentication.Config;
using Staawork.Funaab.HostelPortal.Services.Authentication.Dto;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Authentication
{
    [TestFixture]
    public class UserTokenManagerTests
    {
        private Mock<AuthenticationConfiguration> mockAuthenticationConfiguration;
        private Mock<IDataProtectionProvider>     mockDataProtectionProvider;

        private MockRepository     _mockRepository;
        private Mock<ISystemClock> mockSystemClock;


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            mockAuthenticationConfiguration = _mockRepository.Create<AuthenticationConfiguration>();
            mockDataProtectionProvider = _mockRepository.Create<IDataProtectionProvider>();
            mockSystemClock = _mockRepository.Create<ISystemClock>();
        }


        [Test]
        public async Task GenerateAuthenticationTokenAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            UserProfileDto userProfileDto = null;

            // Act
            var result = await manager.GenerateAuthenticationTokenAsync(
                             userProfileDto);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        [Test]
        public void ParseToken_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            string token = null;

            // Act
            var result = manager.ParseToken(
                token);

            // Assert
            Assert.Fail();
            _mockRepository.VerifyAll();
        }


        private UserTokenManager CreateManager() =>
            new UserTokenManager(
                mockAuthenticationConfiguration.Object,
                mockDataProtectionProvider.Object,
                mockSystemClock.Object);
    }
}