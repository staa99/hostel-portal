using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Commons.Caching
{
    public class RedisCache : IRedisCache
    {
        private readonly IConnectionMultiplexer _redis;


        public RedisCache(ICacheConnector connector)
        {
            _redis = connector.Connect();
            Database = _redis.GetDatabase();
        }


        public void Dispose()
        {
            _redis.Dispose();
        }


        public IDatabaseAsync Database { get; }
    }
}