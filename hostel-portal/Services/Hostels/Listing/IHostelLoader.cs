using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    /// <summary>
    ///     Base interface for high level hostel
    /// </summary>
    public interface IHostelLoader
    {
        /// <summary>
        ///     This API loads the list of hostels, with the prices and availability. It uses the cache, if the list is not in the
        ///     cache, it uses the API and updates the cache.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<HostelDto>> LoadHostels(IHostelCacheChecker cacheChecker,
                                                 IHostelCacheUpdater cacheUpdater,
                                                 IHostelWebApiLoader webApiLoader);
    }
}