using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Payments
{
    public class HostelFeeRedisKeyResolver : IHostelFeeRedisKeyResolver
    {
        /// <inheritdoc />
        public RedisKey Resolve(string source) => new RedisKey("payments").Append("hostel-fees").Append(source);
    }
}