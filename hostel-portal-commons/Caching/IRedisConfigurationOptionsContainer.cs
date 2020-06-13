using Microsoft.Extensions.Options;
using Staawork.Funaab.HostelPortal.Commons.Caching.Config;


namespace Staawork.Funaab.HostelPortal.Commons.Caching
{
    public interface IRedisConfigurationOptionsContainer : IOptionsSnapshot<RedisConfigurationOptions>
    {
        RedisConfigurationOptions Options => Value;
    }
}