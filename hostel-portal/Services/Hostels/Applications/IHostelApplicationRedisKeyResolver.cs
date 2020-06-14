using Staawork.Funaab.HostelPortal.Commons.Caching;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    /// <summary>
    ///     Resolves the RedisKey for hostel applications from the matriculation number
    /// </summary>
    public interface IHostelApplicationRedisKeyResolver : IRedisKeyResolver<string>
    { }
}