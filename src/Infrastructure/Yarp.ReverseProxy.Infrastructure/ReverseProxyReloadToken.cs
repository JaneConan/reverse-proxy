using Microsoft.Extensions.Primitives;

namespace Yarp.ReverseProxy.Infrastructure;
public class ReverseProxyReloadToken : IChangeToken
{
    private CancellationTokenSource _tokenSource = new CancellationTokenSource();
    public void OnReload() => _tokenSource.Cancel();
    public bool ActiveChangeCallbacks { get; } = true;

    public bool HasChanged { get { return _tokenSource.IsCancellationRequested; } }

    public IDisposable RegisterChangeCallback(Action<object> callback, object state)
    {
        return _tokenSource.Token.Register(callback, state);
    }
}
