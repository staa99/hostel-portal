namespace Staawork.Funaab.HostelPortal.Commons.MessageQueue.Config
{
    public class HostelApplicationQueueConfiguration
    {
        public string ExchangeName { get; set; } = "funaab-hostel-exchange";
        public string HostelApplicationQueueName { get; set; } = "hostel-applications";
    }
}