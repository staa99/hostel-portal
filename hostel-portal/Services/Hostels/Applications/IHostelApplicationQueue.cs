using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Dtos;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    public interface IHostelApplicationQueue
    {
        /// <summary>
        ///     Posts a new hostel application to the message queue.
        /// </summary>
        /// <param name="hostelApplicationData"></param>
        /// <returns></returns>
        Task SendNewHostelApplicationAsync(HostelApplicationDto hostelApplicationData);
    }
}