using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Commons.Caching
{
    public interface IRedisKeyResolver<in T>
    {
        RedisKey Resolve(T source);
    }
}