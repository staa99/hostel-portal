using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Config;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Payments
{
    internal class PaymentCacheChecker : IPaymentCacheChecker
    {
        private readonly IRedisCache                           _cache;
        private readonly PaymentConfiguration                  _configuration;
        private readonly IHostelApplicationFeeRedisKeyResolver _keyResolver;


        public PaymentCacheChecker(PaymentConfiguration                  configuration,
                                   IRedisCache                           cache,
                                   IHostelApplicationFeeRedisKeyResolver keyResolver)
        {
            _configuration = configuration;
            _cache = cache;
            _keyResolver = keyResolver;
        }


        /// <inheritdoc />
        public async Task<PaymentDto?> GetPaymentRecordAsync(string matricNumber)
        {
            var paymentKey = _keyResolver.Resolve(matricNumber);
            var map = await _cache.Database.HashGetAllAsync(paymentKey);

            if (map == null || map.Length == 0)
            {
                return null;
            }

            var properties = new Dictionary<string, string>();
            RedisUtilities.MapHashEntriesToDictionary(map,
                                                      properties,
                                                      ConvertRedisHashEntryToStringPair);

            _ = properties.TryGetValue(_configuration.PaymentReferenceCachePropertyKey, out var reference);
            _ = properties.TryGetValue(_configuration.PaymentStatusCachePropertyKey, out var rawStatus);
            _ = Enum.TryParse<PaymentStatus>(rawStatus, out var status);

            return new PaymentDto
            {
                Reference = reference ?? string.Empty,
                Status = rawStatus == null ? PaymentStatus.Nonexistent : status
            };
        }


        private static KeyValuePair<string, string> ConvertRedisHashEntryToStringPair(HashEntry entry) =>
            new KeyValuePair<string, string>(
                entry.Name,
                entry.Value);
    }
}