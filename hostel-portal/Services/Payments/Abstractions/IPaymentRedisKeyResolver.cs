using Staawork.Funaab.HostelPortal.Commons.Caching;


namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions
{
    /// <summary>
    ///     Resolves the RedisKey for payments
    /// </summary>
    internal interface IPaymentRedisKeyResolver : IRedisKeyResolver<string>
    { }
}