using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments
{
    internal class PaymentService : IPaymentService
    {
        /// <inheritdoc />
        public async Task<PaymentDto?> GetPaymentRecordAsync(string                matricNumber,
                                                             IPaymentCacheChecker  cacheChecker,
                                                             IPaymentCacheUpdater  cacheUpdater,
                                                             IPaymentWebApiService webApiService)
        {
            var payment = await cacheChecker.GetPaymentRecordAsync(matricNumber);
            if (payment == null)
            {
                return null;
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
                    Message = "You have already made payment",
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