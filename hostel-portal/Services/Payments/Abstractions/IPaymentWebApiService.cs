using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions
{
    /// <summary>
    ///     The base interface for all payment Web API services in the hostel portal
    /// </summary>
    public interface IPaymentWebApiService
    {
        Task<PaymentDto?>              GetPaymentRecordAsync(string matricNumber);
        Task<InitiatePaymentResultDto> InitiatePaymentAsync(string  matricNumber);
    }
}