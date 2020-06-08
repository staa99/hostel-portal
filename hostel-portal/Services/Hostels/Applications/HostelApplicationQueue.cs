using System;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Dtos;
using Staawork.Funaab.HostelPortal.Commons.MessageQueue;
using Staawork.Funaab.HostelPortal.Commons.MessageQueue.Config;
using Staawork.Funaab.HostelPortal.Commons.Serialization;


namespace Staawork.Funaab.HostelPortal.Services.Hostels.Applications
{
    internal class HostelApplicationQueue : IHostelApplicationQueue
    {
        private readonly HostelApplicationQueueConfiguration _configuration;
        private readonly IHostelApplicationSerializer        _hostelApplicationSerializer;
        private readonly IQueueManager                       _queueManager;


        public HostelApplicationQueue(HostelApplicationQueueConfiguration configuration,
                                      IQueueManager                       queueManager,
                                      IHostelApplicationSerializer        hostelApplicationSerializer)
        {
            _configuration = configuration;
            _queueManager = queueManager;
            _hostelApplicationSerializer = hostelApplicationSerializer;
        }


        public async Task SendNewHostelApplicationAsync(HostelApplicationDto hostelApplicationData)
        {
            // validate hostelApplicationData
            ValidateHostelApplicationData(hostelApplicationData);

            var basicProperties = _queueManager.CreateBasicProperties();
            basicProperties.Persistent = true;

            // The queue name is used as the routing key
            await _queueManager.SendToQueue(hostelApplicationData,
                                            _hostelApplicationSerializer,
                                            new ExchangeDeclarationParameters(
                                                exchangeName: _configuration.ExchangeName),
                                            new QueueDeclarationParameters(_configuration.HostelApplicationQueueName),
                                            new BasicPublishParameters(string.Empty,
                                                                       _configuration.HostelApplicationQueueName,
                                                                       basicProperties));
        }


        private static void ValidateHostelApplicationData(HostelApplicationDto hostelApplicationData)
        {
            if (string.IsNullOrEmpty(hostelApplicationData.MatricNumber))
            {
                throw new ApplicationException("Invalid Matriculation Number: (empty string)");
            }

            if (string.IsNullOrEmpty(hostelApplicationData.HostelId))
            {
                throw new ApplicationException("Invalid Hostel ID: (empty string)");
            }
        }
    }
}