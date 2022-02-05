using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.ReverseProxy.Infrastructure.Data
{
    public interface IReverseProxy
    {
        public event ConfigChangeHandler ChangeConfig;
        IProxyConfig GetConfig();
        void Reload();
        void ReloadConfig();
        IChangeToken GetReloadToken();
    }
}
