using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Common.Proxy.Helpers
{
    public interface IHttpClientHelper
    {
        Task<string> GetStringAsync(string uri, IDictionary<string, string> headers, string token = null);
        Task<HttpResponseMessage> PostPutAsync<T>(string uri, IDictionary<string, string> headers, HttpMethod method, T item, string token = null);
        Task<HttpResponseMessage> DeleteAsync(string uri, IDictionary<string, string> headers, HttpMethod method, string token = null);
    }
}
