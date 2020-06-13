using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal interface IHostelApplicationCacheUpdater
    {
        /// <summary>
        ///     Updates the status of the hostel application in the cache.
        /// </summary>
        /// <param name="applicationDto"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        Task UpdateHostelApplicationStatusAsync(HostelApplicationDto applicationDto, HostelApplicationStatus newStatus);
    }
}