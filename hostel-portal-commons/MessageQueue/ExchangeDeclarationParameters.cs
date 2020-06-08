namespace Staawork.Funaab.HostelPortal.Commons.MessageQueue
{
    public class ExchangeDeclarationParameters
    {
        public ExchangeDeclarationParameters(bool    autoDelete   = false,
                                             bool    durable      = true,
                                             string? exchangeName = null,
                                             string? exchangeType = null)
        {
            AutoDelete = autoDelete;
            Durable = durable;
            ExchangeName = exchangeName ?? string.Empty;
            ExchangeType = exchangeType ?? "direct";
        }


        public bool AutoDelete { get; }
        public bool Durable { get; }
        public string ExchangeName { get; }
        public string ExchangeType { get; }
    }
}