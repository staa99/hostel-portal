using System;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Commons.Caching
{
    /// <summary>
    ///     The singleton cache that initiates its connection on app startup. When disposed, it releases the connection and
    ///     other resources. This is designed to use Redis, since this project is just to explore the basics of Redis, RabbitMQ
    ///     and Docker.
    /// </summary>
    public interface IRedisCache : IDisposable
    {
        IDatabaseAsync Database { get; }
    }
}