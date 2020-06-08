using System.Threading.Tasks;


namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions
{
    internal interface IPaymentStatusCacheUpdater
    {
        Task UpdatePaymentStatusAsync(string matricNumber, object newStatus);
    }
}