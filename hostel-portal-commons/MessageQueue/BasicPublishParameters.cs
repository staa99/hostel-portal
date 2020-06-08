using RabbitMQ.Client;


namespace Staawork.Funaab.HostelPortal.Commons.MessageQueue
{
    public class BasicPublishParameters
    {
        public BasicPublishParameters(string?           exchange        = null,
                                      string?           routingKey      = null,
                                      IBasicProperties? basicProperties = null)
        {
            Exchange = exchange     ?? string.Empty;
            RoutingKey = routingKey ?? string.Empty;
            BasicProperties = basicProperties;
        }


        public IBasicProperties? BasicProperties { get; }

        public string Exchange { get; }
        public string RoutingKey { get; }
    }
}