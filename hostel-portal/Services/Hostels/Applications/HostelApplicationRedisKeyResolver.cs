using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal class HostelApplicationRedisKeyResolver : IHostelApplicationRedisKeyResolver
    {
        public RedisKey Resolve(string source) => new RedisKey("applications").Append(source);
    }
}