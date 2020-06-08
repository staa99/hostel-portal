using System;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Staawork.Funaab.HostelPortal.Commons.Serialization;


namespace Staawork.Funaab.HostelPortal.Commons.MessageQueue
{
    public class RabbitMqQueueManager : IQueueManager
    {
        private readonly IModel      _channel;
        private readonly IConnection _connection;


        public RabbitMqQueueManager(IConnectionFactory connectionFactory)
        {
            var factory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }


        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }


        public IBasicProperties CreateBasicProperties() => _channel.CreateBasicProperties();


        /// <summary>
        ///     Very simple implementation of the queue sender based on the basic tutorials.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="serializer"></param>
        /// <param name="basicPublishParameters"></param>
        /// <returns></returns>
        public async Task SendToQueue<T>(T                             obj,
                                         IObjectSerializer<T>          serializer,
                                         ExchangeDeclarationParameters exchangeDeclarationParameters,
                                         QueueDeclarationParameters    queueDeclarationParameters,
                                         BasicPublishParameters        basicPublishParameters)
        {
            PrepareQueue(exchangeDeclarationParameters, queueDeclarationParameters);

            var message = await serializer.SerializeAsync(obj);
            _channel.BasicPublish(basicPublishParameters.Exchange,
                                  basicPublishParameters.RoutingKey,
                                  basicPublishParameters.BasicProperties,
                                  message);
        }


        private void PrepareQueue(ExchangeDeclarationParameters exchangeDeclarationParameters,
                                  QueueDeclarationParameters    queueDeclarationParameters)
        {
            // create the exchange
            _channel.ExchangeDeclare(exchangeDeclarationParameters.ExchangeName,
                                     exchangeDeclarationParameters.ExchangeType,
                                     exchangeDeclarationParameters.Durable,
                                     exchangeDeclarationParameters.AutoDelete);

            // create the queue
            _channel.QueueDeclare(queueDeclarationParameters.QueueName,
                                  queueDeclarationParameters.Durable,
                                  queueDeclarationParameters.Exclusive,
                                  queueDeclarationParameters.AutoDelete,
                                  queueDeclarationParameters.Arguments);

            // bind the queue to the exchange using the provided routing key as parameter
            _channel.QueueBind(queueDeclarationParameters.QueueName,
                               exchangeDeclarationParameters.ExchangeName,
                               queueDeclarationParameters.BindingKey);
        }
    }
}