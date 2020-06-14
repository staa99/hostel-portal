using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    /// <summary>
    ///     Base interface for high level hostel application.
    /// </summary>
    public interface IHostelApplicationService
    {
        /// <summary>
        ///     Checks the cache for the status of all hostel applications for the given matriculation number.
        /// </summary>
        /// <param name="matricNumber"></param>
        /// <param name="cacheChecker">Checks the cache for the status of the applicant's hostel applications</param>
        /// <returns></returns>
        Task<IDictionary<string, HostelApplicationStatus>> CheckHostelApplicationStatusAsync(
            string                         matricNumber,
            IHostelApplicationCacheChecker cacheChecker);


        /// <summary>
        ///     Checks the cache for the status of all hostel applications for the given matriculation number.
        /// </summary>
        /// <param name="hostelApplicationData">The data to match the hostel application with</param>
        /// <param name="cacheChecker">Checks the cache for the status of the applicant's hostel applications</param>
        /// <returns></returns>
        Task<HostelApplicationStatus> CheckSingleHostelApplicationStatusAsync(
            HostelApplicationDto           hostelApplicationData,
            IHostelApplicationCacheChecker cacheChecker);


        /// <summary>
        ///     Begins the application process for a hostel.
        ///     <br />
        ///     Simply checks the cache if an application exists on the cache for the given student and hostel. If none exists, it
        ///     is added to the cache and placed on the queue.
        ///     <br />
        ///     If an existing hostel application is on the cache, and it is incomplete, the API returns a status indicating an
        ///     ongoing application exists.
        ///     <br />
        ///     If it is complete, but succeeded or failed because of a terminal reason, such as no rooms available, the status is
        ///     returned.
        ///     <br />
        ///     If it is complete but failed because of a non-terminal reason, such as a connection issue, the cache is updated and
        ///     it is added to the queue.
        /// </summary>
        /// <returns></returns>
        Task<InitiateHostelApplicationResultDto> InitiateHostelApplicationAsync(
            HostelApplicationDto           hostelApplicationData,
            IHostelApplicationQueue        hostelApplicationQueue,
            IHostelApplicationCacheChecker cacheChecker,
            IHostelApplicationCacheUpdater cacheUpdater);
    }
}