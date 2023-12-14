using Challenge.bootstrapper.layer.api.Presentation.CustomExceptions;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Challenge.bootstrapper.layer.api.Infrastructure.HttpRequest.Post
{
    public class HttpPost<T> : IHttpPost<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly int DefaultTimeout = 60;

        public HttpPost(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> Request(string client, HttpContent body, AuthenticationHeaderValue? Auth = null, int? Timeout = null, Dictionary<string, string>? Headers = null)
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
                throw new CustomException("El uri: '" + response.RequestMessage.RequestUri.AbsoluteUri + "' respondió: " + responseString);


            var JsonContent = JsonSerializer.Deserialize<T>(responseString);

            if (JsonContent is null)
                throw new Exception("Error al serializar respuesta");

            return JsonContent;
        }
    }
}
