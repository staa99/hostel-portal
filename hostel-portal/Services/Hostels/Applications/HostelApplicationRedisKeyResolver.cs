using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    public class HostelApplicationRedisKeyResolver : IHostelApplicationRedisKeyResolver
    {
        public RedisKey Resolve(string source) => new RedisKey("applications").Append(source);
    }
}