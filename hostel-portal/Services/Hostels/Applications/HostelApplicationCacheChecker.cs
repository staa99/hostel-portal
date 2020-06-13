using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    public class HostelApplicationCacheChecker : IHostelApplicationCacheChecker
    {
        private readonly IRedisCache                        _cache;
        private readonly IHostelApplicationRedisKeyResolver _keyResolver;


        public HostelApplicationCacheChecker(IRedisCache cache, IHostelApplicationRedisKeyResolver keyResolver)
        {
            _cache = cache;
            _keyResolver = keyResolver;
        }


        public async Task<IDictionary<string, HostelApplicationStatus>> CheckHostelApplicationStatusAsync(
            string matricNumber)
        {
            var applicationMapKey = _keyResolver.Resolve(matricNumber);
            var map = await _cache.Database.HashGetAllAsync(applicationMapKey);
            var result = new Dictionary<string, HostelApplicationStatus>();

            RedisUtilities.MapHashEntriesToDictionary(map, result, ConvertRedisHashEntryToHostelApplicationStatus);
            return result;
        }


        public async Task<HostelApplicationStatus> CheckSingleHostelApplicationStatusAsync(
            HostelApplicationDto applicationData)
        {
            var applicationMapKey = _keyResolver.Resolve(applicationData.MatricNumber);
            var redisValue = await _cache.Database.HashGetAsync(applicationMapKey, applicationData.HostelId);
            return ParseStatus(redisValue);
        }


        private static KeyValuePair<string, HostelApplicationStatus> ConvertRedisHashEntryToHostelApplicationStatus(
            HashEntry entry)
        {
            var status = ParseStatus(entry.Value);
            return new KeyValuePair<string, HostelApplicationStatus>(entry.Name, status);
        }


        private static HostelApplicationStatus ParseStatus(RedisValue redisValue)
        {
            HostelApplicationStatus status;
            if (redisValue == RedisValue.Null || redisValue == RedisValue.EmptyString)
            {
                status = HostelApplicationStatus.Nonexistent;
            }
            else if (!Enum.TryParse(redisValue, out status))
            {
                status = HostelApplicationStatus.FailedUnknownReason;
            }

            return status;
        }
    }
}