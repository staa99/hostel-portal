using NUnit.Framework;
using Shouldly;
using Staawork.Funaab.HostelPortal.Services.Payments;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Tests.Services.Payments
{
    [TestFixture]
    public class HostelFeeRedisKeyResolverTests
    {
        [Test]
        public void Resolve_WhenCalled_ShouldCreateRedisKeyInDefinedFormat()
        {
            // Arrange
            var hostelApplicationFeeRedisKeyResolver = CreateHostelFeeRedisKeyResolver();
            var source = "matric-number";
            var expectedResult = new RedisKey("payments").Append("hostel-fees").Append(source);

            // Act
            var result = hostelApplicationFeeRedisKeyResolver.Resolve(source);

            // Assert
            result.ShouldBe(expectedResult);
        }


        private HostelFeeRedisKeyResolver CreateHostelFeeRedisKeyResolver() => new HostelFeeRedisKeyResolver();
    }
}