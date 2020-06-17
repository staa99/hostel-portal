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

        private MockRepository     mockRepository;
        private Mock<ISystemClock> mockSystemClock;


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
            mockRepository.VerifyAll();
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
            mockRepository.VerifyAll();
        }


        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockAuthenticationConfiguration = mockRepository.Create<AuthenticationConfiguration>();
            mockDataProtectionProvider = mockRepository.Create<IDataProtectionProvider>();
            mockSystemClock = mockRepository.Create<ISystemClock>();
        }


        private UserTokenManager CreateManager() =>
            new UserTokenManager(
                mockAuthenticationConfiguration.Object,
                mockDataProtectionProvider.Object,
                mockSystemClock.Object);
    }
}