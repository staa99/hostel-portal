using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Caching;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal class HostelApplicationCacheUpdater : IHostelApplicationCacheUpdater
    {
        private readonly IRedisCache                        _cache;
        private readonly IHostelApplicationRedisKeyResolver _keyResolver;


        public HostelApplicationCacheUpdater(IRedisCache cache, IHostelApplicationRedisKeyResolver keyResolver)
        {
            _cache = cache;
            _keyResolver = keyResolver;
        }


        public async Task UpdateHostelApplicationStatusAsync(HostelApplicationDto    applicationDto,
                                                             HostelApplicationStatus newStatus)
        {
            var key = _keyResolver.Resolve(applicationDto.MatricNumber);
            await _cache.Database.HashSetAsync(key, applicationDto.HostelId, newStatus.ToString());
        }
    }
}