namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto
{
    public sealed class InitiatePaymentResultDto
    {
        public string Message { get; set; }
        public PaymentDto PaymentInfo { get; set; }
    }
}