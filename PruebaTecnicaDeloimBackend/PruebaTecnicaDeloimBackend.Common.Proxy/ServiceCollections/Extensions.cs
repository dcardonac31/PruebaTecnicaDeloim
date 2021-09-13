using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaDeloimBackend.Common.Proxy.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.Proxy.ServiceCollections
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IServiceCollection AddProxyHttp(this IServiceCollection services)
        {
            services.AddSingleton<IHttpClientHelper, HttpClientHelper>();
            return services;
        }
    }
}
