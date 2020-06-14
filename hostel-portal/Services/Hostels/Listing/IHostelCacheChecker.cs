using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    public interface IHostelCacheChecker
    {
        /// <summary>
        ///     Loads tbe list of hostels from the cache
        /// </summary>
        /// <returns></returns>
        Task<ICollection<HostelDto>> LoadHostels();
    }
}