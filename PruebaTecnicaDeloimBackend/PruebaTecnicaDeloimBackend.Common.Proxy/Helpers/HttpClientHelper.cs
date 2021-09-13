using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PruebaTecnicaDeloimBackend.Common.Proxy.Helpers
{
    [ExcludeFromCodeCoverage]
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _client;

        public HttpClientHelper()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetStringAsync(string uri, IDictionary<string, string> headers, string token = null)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            _client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrWhiteSpace(token))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);

            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            var response = await _client.SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> PostPutAsync<T>(string uri, IDictionary<string, string> headers, HttpMethod method, T item, string token = null)
        {
            return await DoPostPutAsync(method, uri, headers, method, token);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri, IDictionary<string, string> headers, HttpMethod method, string token = null)
        {
            return await DoDeleteAsync(uri, headers, method, token);
        }


        #region Method Private
        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri, IDictionary<string, string> headers, T item, string token = null)
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
            {
                throw new ArgumentException("Value must be either post or put.", nameof(method));
            }

            var requestMessage = new HttpRequestMessage(method, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            _client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrWhiteSpace(token))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);

            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            var response = await _client.SendAsync(requestMessage);

            // raise exception if HttpResponseCode 500
            // needed for circuit breaker to track fails

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }

            return response;
        }

        private async Task<HttpResponseMessage> DoDeleteAsync(string uri, IDictionary<string, string> headers, HttpMethod method, string token = null)
        {
            var requestMessage = new HttpRequestMessage(method, uri);

            _client.DefaultRequestHeaders.Accept.Clear();

            if (!string.IsNullOrWhiteSpace(token))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);

            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            var response = await _client.SendAsync(requestMessage);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }

            return response;
        }
        #endregion Method Private
    }
}
