using Microsoft.Extensions.Logging;

namespace Yarp.ReverseProxy.Infrastructure.Data
{
    public class EventIds
    {
        public static readonly EventId LoadData = new EventId(1, "ApplyProxyConfig");
        public static readonly EventId ErrorSignalingChange = new EventId(2, "ApplyProxyConfigFailed");
        public static readonly EventId ConfigurationDataConversionFailed = new EventId(3, "ConfigurationDataConversionFailed");
    }
}
