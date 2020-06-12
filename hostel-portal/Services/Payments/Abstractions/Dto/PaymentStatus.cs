namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Dto
{
    public enum PaymentStatus
    {
        Nonexistent,
        Initiated,
        Paid,
        Failed
    }


    public class PaymentDto
    {
        public string Reference { get; set; }
        public PaymentStatus Status { get; set; }
    }
}