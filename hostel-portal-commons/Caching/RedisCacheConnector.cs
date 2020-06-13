using System;
using System.IO;
using System.Threading.Tasks;
using Staawork.Funaab.HostelPortal.Commons.Caching.Config;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Commons.Caching
{
    public class RedisCacheConnector : ICacheConnector
    {
        private readonly TextWriter?               _logWriter;
        private readonly RedisConfigurationOptions _options;


        public RedisCacheConnector(IRedisConfigurationOptionsContainer optionsContainer)
        {
            _options = optionsContainer.Options;
            if (_options.LogToConsole)
            {
                _logWriter = Console.Out;
            }
        }


        public IConnectionMultiplexer Connect()
        {
            var options = ParseOptions();
            return ConnectionMultiplexer.Connect(options, _logWriter);
        }


        public async Task<IConnectionMultiplexer> ConnectAsync()
        {
            var options = ParseOptions();
            return await ConnectionMultiplexer.ConnectAsync(options, _logWriter);
        }


        private ConfigurationOptions ParseOptions()
        {
            var options = new ConfigurationOptions();
            foreach (var endpoint in _options.Endpoints)
            {
                options.EndPoints.Add(endpoint);
            }

            options.Ssl = _options.UseSSl;
            options.AllowAdmin = _options.AllowAdmin;

            return options;
        }
    }
}