using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions
{
    /// <summary>
    ///     The base interface for all hostel payment status cache checkers
    /// </summary>
    internal interface IPaymentCacheChecker
    {
        Task<PaymentDto?> GetPaymentRecordAsync(string matricNumber);
    }
}