using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Hostels.Applications.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal interface IHostelApplicationQueue
    {
        /// <summary>
        ///     Posts a new hostel application to the message queue.
        /// </summary>
        /// <param name="hostelApplicationData"></param>
        /// <returns></returns>
        Task SendNewHostelApplicationAsync(HostelApplicationDto hostelApplicationData);
    }
}