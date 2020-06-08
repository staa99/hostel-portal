using Microsoft.Extensions.Options;
using Staawork.Funaab.HostelPortal.Caching.Config;


namespace Staawork.Funaab.HostelPortal.Caching
{
    public interface IRedisConfigurationOptionsContainer : IOptionsSnapshot<RedisConfigurationOptions>
    {
        RedisConfigurationOptions Options => Value;
    }
}