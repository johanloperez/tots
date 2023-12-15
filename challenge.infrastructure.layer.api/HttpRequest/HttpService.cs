using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.api.HttpRequest
{
    public class HttpService<T> : IHttpService<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly int DefaultTimeout = 60;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> Post(string client, HttpContent body, AuthenticationHeaderValue? Auth = null, int? Timeout = null, Dictionary<string, string>? Headers = null)
        {
            var httpClient = _httpClientFactory.CreateClient(client);
            httpClient.Timeout = TimeSpan.FromSeconds(Timeout ?? DefaultTimeout);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            if (Auth is not null)
            {
                httpClient.DefaultRequestHeaders.Authorization = Auth;
            }

            if (Headers != null && Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Key, Header.Value);
                }
            }
            var response = await httpClient.PostAsync(string.Empty, body);

            if (response is null)
                throw new Exception($"Error al intentar llamar al servidor: {httpClient.BaseAddress}");

            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("El uri: '" + response.RequestMessage.RequestUri.AbsoluteUri + "' respondió: " + responseString);


            var JsonContent = JsonSerializer.Deserialize<T>(responseString);

            if (JsonContent is null)
                throw new Exception("Error al serializar respuesta");

            return JsonContent;
        }
        public async Task<T> Get(string client, AuthenticationHeaderValue? Auth = null, int? Timeout = null, Dictionary<string, string>? Headers = null)
        {
            var httpClient = _httpClientFactory.CreateClient(client);
            httpClient.Timeout = TimeSpan.FromSeconds(Timeout ?? DefaultTimeout);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            if (Auth is not null)
            {
                httpClient.DefaultRequestHeaders.Authorization = Auth;
            }

            if (Headers != null && Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Key, Header.Value);
                }
            }

            var response = await httpClient.GetAsync(string.Empty);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var JsonContent = JsonSerializer.Deserialize<T>(responseString);

                if (JsonContent is null)
                    throw new Exception("Error al serializar respuesta");

                return JsonContent;
            }
            else
            {
                throw new Exception("El uri: '" + httpClient.BaseAddress + "' respondió: " + response.ReasonPhrase);
            }
        }
    }
}
