using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Payments
{
    public class HostelApplicationFeeRedisKeyResolver : IHostelApplicationFeeRedisKeyResolver
    {
        /// <inheritdoc />
        public RedisKey Resolve(string source) =>
            new RedisKey("payments").Append("hostel-application-fees").Append(source);
    }
}