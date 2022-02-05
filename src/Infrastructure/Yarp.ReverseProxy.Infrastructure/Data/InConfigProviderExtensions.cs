using Microsoft.Extensions.Logging;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InConfigProviderExtensions
    {
        public static IReverseProxyBuilder LoadFromDataBase(this IReverseProxyBuilder builder)
        {
            builder.Services.AddSingleton<IProxyConfigProvider>(sp =>
            {
                return new InConfigProvider(sp.GetService<ILogger<InConfigProvider>>(), sp.GetRequiredService<IReverseProxy>());
            });
            return builder;
        }
    }
}
