using System.Collections.Generic;


namespace Staawork.Funaab.HostelPortal.Commons.MessageQueue
{
    public class QueueDeclarationParameters
    {
        public QueueDeclarationParameters(string?                      queueName  = null,
                                          string?                      bindingKey = null,
                                          bool                         durable    = true,
                                          bool                         exclusive  = false,
                                          bool                         autoDelete = false,
                                          IDictionary<string, object>? arguments  = null)
        {
            QueueName = queueName   ?? string.Empty;
            BindingKey = bindingKey ?? QueueName;
            Durable = durable;
            Exclusive = exclusive;
            AutoDelete = autoDelete;
            Arguments = arguments;
        }


        public IDictionary<string, object>? Arguments { get; }
        public bool AutoDelete { get; }
        public string BindingKey { get; }
        public bool Durable { get; }
        public bool Exclusive { get; }
        public string QueueName { get; }
    }
}