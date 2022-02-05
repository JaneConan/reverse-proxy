using FluentValidation;
using Yarp.ReverseProxy.Infrastructure.Entity;

namespace BasicYARPSample.Validator
{
    public class ProxyRouteValidator : AbstractValidator<ProxyRoute>
    {
        public ProxyRouteValidator()
        {
            RuleFor(x => x.Match.Methods)
                .Must(methods =>
                {
                    var ms = new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS", "HEAD", "CONNECT", "OPTIONS", "TRACE", "PATCH" };
                    var arr = methods.Split(",");
                    if (arr.Length > 0)
                    {
                        return arr.All(a => ms.Contains(a));
                    }
                    return true;
                })
                .When(x => x.Match != null)
                .WithMessage("ProxyRoute.Match.Methods must in (GET, POST, PUT, DELETE, OPTIONS, HEAD, CONNECT, OPTIONS, TRACE, PATCH)")
                ;
        }
    }
}
