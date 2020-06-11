using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    internal class HostelLoader : IHostelLoader
    {
        /// <inheritdoc />
        public async Task<ICollection<HostelDto>> LoadHostels(IHostelCacheChecker cacheChecker,
                                                              IHostelCacheUpdater cacheUpdater,
                                                              IHostelWebApiLoader webApiLoader)
        {
            var hostels = await cacheChecker.LoadHostels();
            if (hostels.Any())
            {
                return hostels;
            }

            hostels = await webApiLoader.LoadHostels();
            if (hostels.Any())
            {
                await cacheUpdater.UpdateHostels(hostels);
            }

            return hostels;
        }
    }
}