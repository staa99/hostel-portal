using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        /// <summary>
        ///     Message returned when payment has already been made. Localization is not used because the system is designed simply
        ///     for learning purposes and not for real production use.
        /// </summary>
        public const string AlreadyPaidMessage = "You have already made payment";


        /// <inheritdoc />
        public async Task<PaymentDto?> GetPaymentRecordAsync(string                matricNumber,
                                                             IPaymentCacheChecker  cacheChecker,
                                                             IPaymentCacheUpdater  cacheUpdater,
                                                             IPaymentWebApiService webApiService)
        {
            var payment = await cacheChecker.GetPaymentRecordAsync(matricNumber);
            if (payment != null)
            {
                return payment;
            }

            payment = await webApiService.GetPaymentRecordAsync(matricNumber);
            if (payment != null)
            {
                await cacheUpdater.UpdatePaymentRecordAsync(matricNumber, payment);
            }

            return payment;
        }


        /// <inheritdoc />
        public async Task<InitiatePaymentResultDto> InitiatePaymentAsync(string                matricNumber,
                                                                         IPaymentCacheChecker  cacheChecker,
                                                                         IPaymentCacheUpdater  cacheUpdater,
                                                                         IPaymentWebApiService webApiService)
        {
            var payment = await cacheChecker.GetPaymentRecordAsync(matricNumber);

            if (payment?.Status == PaymentStatus.Paid)
            {
                return new InitiatePaymentResultDto
                {
                    Message = AlreadyPaidMessage,
                    PaymentInfo = payment
                };
            }

            // it's not been paid, the user is doing this because they need to re-initiate the payment or begin a new payment
            var result = await webApiService.InitiatePaymentAsync(matricNumber);
            await cacheUpdater.UpdatePaymentRecordAsync(matricNumber, result.PaymentInfo);
            return result;
        }
    }
}