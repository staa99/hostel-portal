namespace Staawork.Funaab.HostelPortal.Commons.Caching.Config
{
    public class RedisConfigurationOptions
    {
        public bool AllowAdmin { get; set; } = false;
        public string[] Endpoints { get; set; }
        public bool LogToConsole { get; set; } = true;
        public bool UseSSl { get; set; } = true;
    }
}