using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions
{
    /// <summary>
    ///     The base interface for high-level payment services in the hostel portal
    /// </summary>
    internal interface IPaymentService
    {
        /// <summary>
        ///     Checks the cache for the status of the payment. If it is not present, it checks the Web API service and updates the
        ///     cache accordingly.
        /// </summary>
        /// <param name="matricNumber">The matric number to check payment status for</param>
        /// <param name="cacheChecker">The cache reader to check the cache with</param>
        /// <param name="cacheUpdater">The cache writer to update the cache with</param>
        /// <param name="webApiService">The payment Web API service to use in initiating the payment</param>
        /// <returns></returns>
        Task<PaymentStatus> CheckPaymentStatusAsync(string                     matricNumber,
                                                    IPaymentStatusCacheChecker cacheChecker,
                                                    IPaymentStatusCacheUpdater cacheUpdater,
                                                    IPaymentWebApiService      webApiService);


        /// <summary>
        ///     Initiates the hostel application payment process and gets the payment URL.
        ///     <br />
        ///     <br />
        ///     If the status in the cache is paid, it returns a response to indicate the person has paid.
        ///     <br />
        ///     Otherwise, it uses the API to initiate the hostel application fee payment
        /// </summary>
        /// <param name="matricNumber">The matric number to initiate payment for</param>
        /// <param name="cacheChecker">The reader to check the cache with</param>
        /// <param name="webApiService">The payment Web API service to use in initiating the payment</param>
        /// <returns></returns>
        Task<InitiatePaymentResultDto> InitiatePaymentAsync(string                     matricNumber,
                                                            IPaymentStatusCacheChecker cacheChecker,
                                                            IPaymentWebApiService      webApiService);
    }
}