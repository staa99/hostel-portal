using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Config;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    internal class HostelCacheUpdater : IHostelCacheUpdater
    {
        private readonly IRedisCache _cache;


        public HostelCacheUpdater(IRedisCache cache)
        {
            _cache = cache;
        }


        /// <inheritdoc />
        public async Task UpdateHostels(IEnumerable<HostelDto> hostels)
        {
            var map = hostels.Select(h => new HashEntry(h.Id, JsonConvert.SerializeObject(h))).ToArray();
            await _cache.Database.HashSetAsync(HostelListingConfiguration.HostelMapKey, map);
        }
    }
}