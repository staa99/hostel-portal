using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal interface IRedisKeyResolver<in T>
    {
        RedisKey Resolve(T source);
    }
}