using System;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions;
using Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto;


namespace Staawork.Funaab.HostelPortal.Services.Payments
{
    public class PaymentWebApiService : IPaymentWebApiService
    {
        private PaymentStatus currentMockStatus = PaymentStatus.Nonexistent;


        /// <inheritdoc />
        public async Task<PaymentDto?> GetPaymentRecordAsync(string matricNumber)
        {
            // use a stub until we have access to the main system

            // fake a delay
            await Task.Delay(1000);

            if (matricNumber != "20163097")
            {
                return null;
            }

            var result = new PaymentDto
            {
                Reference = "ref_123456",
                Status = currentMockStatus
            };

            UpdateStatus();
            return result;
        }


        /// <inheritdoc />
        public async Task<InitiatePaymentResultDto> InitiatePaymentAsync(string matricNumber)
        {
            // this is just a stub until we have access to the main system

            // fake a delay
            await Task.Delay(1000);

            if (matricNumber != "20163097")
            {
                return new InitiatePaymentResultDto
                {
                    Message = "Invalid Matriculation Number",
                    PaymentInfo = new PaymentDto
                    {
                        Status = PaymentStatus.Nonexistent,
                        Reference = string.Empty
                    }
                };
            }

            return new InitiatePaymentResultDto
            {
                Message = "Successfully Initiated Payment",
                PaymentInfo = new PaymentDto
                {
                    Reference = "ref_123456",
                    Status = PaymentStatus.Initiated
                }
            };
        }


        private void UpdateStatus()
        {
            switch (currentMockStatus)
            {
                case PaymentStatus.Nonexistent:
                    break;
                case PaymentStatus.Initiated:
                    currentMockStatus = PaymentStatus.Failed;
                    break;
                case PaymentStatus.Paid:
                    break;
                case PaymentStatus.Failed:
                    currentMockStatus = PaymentStatus.Paid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}