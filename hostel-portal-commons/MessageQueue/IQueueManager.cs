using System;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Staawork.Funaab.HostelPortal.Commons.Serialization;


namespace Staawork.Funaab.HostelPortal.Commons.MessageQueue
{
    public interface IQueueManager : IDisposable
    {
        IBasicProperties CreateBasicProperties();


        Task SendToQueue<T>(T                             obj,
                            IObjectSerializer<T>          serializer,
                            ExchangeDeclarationParameters exchangeDeclarationParameters,
                            QueueDeclarationParameters    queueDeclarationParameters,
                            BasicPublishParameters        basicPublishParameters);
    }
}