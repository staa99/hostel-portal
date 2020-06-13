using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Config;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments
{
    internal class PaymentCacheUpdater : IPaymentCacheUpdater
    {
        private readonly IRedisCache                           _cache;
        private readonly PaymentConfiguration                  _configuration;
        private readonly IHostelApplicationFeeRedisKeyResolver _keyResolver;


        public PaymentCacheUpdater(PaymentConfiguration                  configuration,
                                   IRedisCache                           cache,
                                   IHostelApplicationFeeRedisKeyResolver keyResolver)
        {
            _configuration = configuration;
            _cache = cache;
            _keyResolver = keyResolver;
        }


        /// <inheritdoc />
        public async Task UpdatePaymentRecordAsync(string matricNumber, PaymentDto paymentRecord)
        {
            var paymentKey = _keyResolver.Resolve(matricNumber);

            var properties = new Dictionary<string, string>
            {
                [_configuration.PaymentReferenceCachePropertyKey] = paymentRecord.Reference,
                [_configuration.PaymentStatusCachePropertyKey] = paymentRecord.Status.ToString()
            };

            var entries =
                RedisUtilities.MapDictionaryToHashEntries(properties, RedisUtilities.MapStringPairToHashEntry);

            await _cache.Database.HashSetAsync(paymentKey, entries);
        }
    }
}