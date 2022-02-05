using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Infrastructure.Data;

namespace Yarp.ReverseProxy.Infrastructure;
public static class ReverseProxyExtensions
{
    public static IReverseProxyBuilder LoadFromEFCore(this IReverseProxyBuilder builder)
    {
        builder.Services.AddSingleton<IReverseProxy, ReverseProxyReverseProxy>();
        builder.LoadFromDataBase();
        return builder;
    }
}
