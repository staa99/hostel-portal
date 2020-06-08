using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Hostels.Listing.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Listing
{
    internal interface IHostelWebApiLoader
    {
        /// <summary>
        ///     Loads the hostel data from the Web API
        /// </summary>
        /// <returns></returns>
        Task<ICollection<HostelDto>> LoadHostels();
    }
}