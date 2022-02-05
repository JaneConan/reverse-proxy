using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.ReverseProxy.Infrastructure.Data
{
    public class ProxyConfig : IProxyConfig
    {
        public List<RouteConfig> Routes { get; internal set; } = new List<RouteConfig>();

        public List<ClusterConfig> Clusters { get; internal set; } = new List<ClusterConfig>();

        public IChangeToken ChangeToken { get; internal set; }

        IReadOnlyList<RouteConfig> IProxyConfig.Routes => Routes;

        IReadOnlyList<ClusterConfig> IProxyConfig.Clusters => Clusters;
    }
}
