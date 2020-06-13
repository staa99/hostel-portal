using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    internal interface IHostelCacheUpdater
    {
        /// <summary>
        ///     Update the hostels with the given data
        /// </summary>
        /// <returns></returns>
        Task UpdateHostels(IEnumerable<HostelDto> hostels);
    }
}