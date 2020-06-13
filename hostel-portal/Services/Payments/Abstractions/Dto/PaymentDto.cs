namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto
{
    public class PaymentDto
    {
        public string Reference { get; set; }
        public PaymentStatus Status { get; set; }
    }
}