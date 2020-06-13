namespace Staawork.Funaab.HostelPortal.Services.Payments.Abstractions.Config
{
    public class PaymentConfiguration
    {
        public string PaymentInitializationUrl { get; set; }
        public string PaymentReferenceCachePropertyKey { get; set; }
        public string PaymentStatusCachePropertyKey { get; set; }
    }
}