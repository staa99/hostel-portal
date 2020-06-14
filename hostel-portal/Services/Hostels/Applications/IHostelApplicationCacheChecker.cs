using System.Collections.Generic;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    public interface IHostelApplicationCacheChecker
    {
        /// <summary>
        ///     Checks the cache for statuses of all hostel applications of the student.
        /// </summary>
        /// <param name="matricNumber"></param>
        /// <returns></returns>
        Task<IDictionary<string, HostelApplicationStatus>> CheckHostelApplicationStatusAsync(string matricNumber);


        /// <summary>
        ///     Checks the cache for the status of the student's application for the specified hostel
        /// </summary>
        /// <returns></returns>
        Task<HostelApplicationStatus> CheckSingleHostelApplicationStatusAsync(HostelApplicationDto applicationData);
    }
}