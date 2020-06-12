using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions
{
    internal interface IPaymentCacheUpdater
    {
        Task UpdatePaymentRecordAsync(string matricNumber, PaymentDto newStatus);
    }
}