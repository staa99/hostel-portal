﻿using System.Threading.Tasks;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Commons.Caching
{
    public interface ICacheConnector
    {
        IConnectionMultiplexer       Connect();
        Task<IConnectionMultiplexer> ConnectAsync();
    }
}