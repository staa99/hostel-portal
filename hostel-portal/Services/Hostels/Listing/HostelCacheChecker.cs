using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Config;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    public class HostelCacheChecker : IHostelCacheChecker
    {
        private readonly IRedisCache _cache;


        public HostelCacheChecker(IRedisCache cache)
        {
            _cache = cache;
        }


        /// <inheritdoc />
        public async Task<ICollection<HostelDto>> LoadHostels()
        {
            var map = await _cache.Database.HashGetAllAsync(HostelListingConfiguration.HostelMapKey);
            if (map == null)
            {
                return Array.Empty<HostelDto>();
            }

            var hostels = map.Select(entry => JsonConvert.DeserializeObject<HostelDto>(entry.Value)).ToList();
            return hostels;
        }
    }
}