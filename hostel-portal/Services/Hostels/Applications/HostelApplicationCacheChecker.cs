using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal class HostelApplicationCacheChecker : IHostelApplicationCacheChecker
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

            MapHashEntriesToDictionary(map, result);
            return result;
        }


        public async Task<HostelApplicationStatus> CheckSingleHostelApplicationStatusAsync(
            HostelApplicationDto applicationData)
        {
            var applicationMapKey = _keyResolver.Resolve(applicationData.MatricNumber);
            var redisValue = await _cache.Database.HashGetAsync(applicationMapKey, applicationData.HostelId);
            return ParseStatus(redisValue);
        }


        private static void MapHashEntriesToDictionary(IEnumerable<HashEntry>                       map,
                                                       IDictionary<string, HostelApplicationStatus> result)
        {
            foreach (var entry in map)
            {
                var status = ParseStatus(entry.Value);
                result[entry.Name] = status;
            }
        }


        private static HostelApplicationStatus ParseStatus(RedisValue redisValue)
        {
            if (!Enum.TryParse(redisValue, out HostelApplicationStatus status))
            {
                status = HostelApplicationStatus.FailedUnknownReason;
            }

            return status;
        }
    }
}