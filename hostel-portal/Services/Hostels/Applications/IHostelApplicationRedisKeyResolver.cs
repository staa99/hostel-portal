namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    /// <summary>
    ///     Resolves the RedisKey for hostel applications from the matriculation number
    /// </summary>
    internal interface IHostelApplicationRedisKeyResolver : IRedisKeyResolver<string>
    { }
}